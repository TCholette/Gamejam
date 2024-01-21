using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amazon.Polly;
using Amazon.Runtime;
using Amazon;
using Amazon.Polly.Model;
using System.IO;
using System;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class TextToSpeech : MonoBehaviour
{
    [SerializeField] private AudioSource englishAudioSource;
    [SerializeField] private AudioSource conlangAudioSource;
    public string AIVoice;

    public async void StartAudio() {
        await AudioAsync();
    }

    async Task AudioAsync() {
        string conlang = LanguageTranslator.EnglishToConlang(OpenAI.text);

        Task conlangAudioTask = AWSAudio(conlang, AIVoice, conlangAudioSource);
        await Task.Delay(5000);
        Task englishAudioTask = AWSAudio(OpenAI.text, "Gregory", englishAudioSource);

        await Task.WhenAll(englishAudioTask, conlangAudioTask);

        OpenAI.validResponse = false;
    }

    private async Task AWSAudio(string text, string voice, AudioSource audioSource)
    {
        var credentials = new BasicAWSCredentials("AKIAZQ3DUQMNN665ML54", "ZdbVA/xKowaWVq+JNdUtfVHFgPV6YVogZ4VDRlhS");
        var client = new AmazonPollyClient(credentials, RegionEndpoint.USEast1);

        var request = new SynthesizeSpeechRequest()
        {
            Text = text,
            Engine = Engine.Neural,
            VoiceId = VoiceId.FindValue(voice),
            OutputFormat = OutputFormat.Mp3
        };

        var response = await client.SynthesizeSpeechAsync(request, destroyCancellationToken);

        WriteIntoFile(response.AudioStream);

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip($"{Application.dataPath}/audio.mp3", AudioType.MPEG)) {
            var operation = www.SendWebRequest();

            while (!operation.isDone) {
                await Task.Delay(1000);
            }

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.LogError(www.error);
            } else {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }

    private void WriteIntoFile(Stream stream){
        using (var fileStream = new FileStream($"{Application.dataPath}/audio.mp3", FileMode.Create)){
            byte[] buffer = new byte[8*1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length))>0){
                fileStream.Write(buffer, 0, bytesRead);
            }
        }
    }

}
