using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioClip[] _Sounds;

	private void PlayAudioClip(int index)
	{
		GameObject go = new GameObject("AudioClip"); 
		MonoBehaviour.DontDestroyOnLoad(go); 
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip = _Sounds[index];
		source.Play();
		MonoBehaviour.Destroy(go, _Sounds[index].length); 
	}

	public void PlaySoundFireLarge()
	{
		PlayAudioClip(1);
	}

	public void PlaySoundJump01()
	{
		PlayAudioClip(2);
	}

	public void PlaySoundJump02()
	{
		PlayAudioClip(3);
	}
}
