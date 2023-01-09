using SCN.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace SCN.Audio
{
	[CreateAssetMenu(fileName = "Audio global", menuName = "SCN/Scriptable Objects/Audio default")]
	public class AudioGlobal : ScriptableObject
	{
		static AudioGlobal instance;
		public static AudioGlobal Instance
		{
			get
			{
				if (instance == null)
				{
					Setup();
				}

				return instance;
			}
		}

		static void Setup()
		{
			instance = LoadSource.LoadObject<AudioGlobal>("Audio global");
			if (instance == null)
			{
				Debug.LogError("Create 'Audio global' in Resources" +
					".SCN => Scriptable Objects => Audio default");

				return;
			}

			instance.happyVoiceLength = instance.happyVoices.Length;
			instance.happyVoiceRandom = new RandomNoRepeat<AudioClip>(instance.happyVoices);
		}

		[Space(2)]
		[Header("Action sound")]
		[SerializeField] AudioClip[] actionSounds;

		[Space(4)]
		[Header("Character special")]
		[SerializeField] AudioClip[] characterSpecialVoices;

		[Space(4)]
		[Header("Happy voice")]
		[SerializeField] AudioClip[] happyVoices;

		[Space(4)]
		[Header("Greeting")]
		[SerializeField] AudioClip[] greetingVoices; // 0: hello, 1: goodbye

		int happyVoiceLength;
		RandomNoRepeat<AudioClip> happyVoiceRandom;

		#region Action sound
		public void PlayActionSound(ActionOp actionOp)
		{
			AudioPlayer.Instance.PlaySound(actionSounds[(int)actionOp]);
		}
		#endregion

		#region Character special
		public void PlayCharacterSpecialVoice(CharacterSpecialOp characterSpecialOp)
		{
			AudioPlayer.Instance.PlaySound(characterSpecialVoices[(int)characterSpecialOp]);
		}
		#endregion

		#region Happy voice
		public void PlayHappyVoice(HappyOp happyOp)
		{
			AudioPlayer.Instance.PlaySound(happyVoices[(int)happyOp]);
		}

		public void PlayRandomHappyVoice()
		{
			AudioPlayer.Instance.PlaySound(happyVoices[Random.Range(0, happyVoiceLength)]);
		}

		public void PlayRandomNoRepeatHappyVoice()
		{
			AudioPlayer.Instance.PlaySound(happyVoiceRandom.Random());
		}
		#endregion

		#region Greeting
		public void PlayGreetingVoice(GreetingOp greetingOp)
		{
			AudioPlayer.Instance.PlaySound(greetingVoices[(int)greetingOp]);
		}
		#endregion

		public enum ActionOp
		{
			/// <summary>
			/// Khi bam vao button
			/// </summary>
			Btn = 0,
			/// <summary>
			/// Khi hoan thanh 1 session choi
			/// </summary>
			Complete = 1,
			/// <summary>
			/// Khi 1 object nao do duoc show ra
			/// </summary>
			PopUp = 2,
			/// <summary>
			/// Khi thuc hien hanh dong dung
			/// </summary>
			Correct = 3,
			/// <summary>
			/// Khi thuc hien hanh dong sai
			/// </summary>
			Wrong = 4
		}

		public enum CharacterSpecialOp
		{
			/// <summary>
			/// Tieng Hooray cua nam
			/// </summary>
			BoyHooray = 0,
			/// <summary>
			/// Tieng Hooray cua nu
			/// </summary>
			GirlHooray = 1,
			/// <summary>
			/// Tieng hu' cua nam
			/// </summary>
			BoyHowling = 0,
			/// <summary>
			/// Tieng hu' cua nu
			/// </summary>
			GirlHowling = 1
		}

		public enum HappyOp
		{
			Cool = 0,
			GreatJob = 1,
			ILikeIt = 2,
			Perfect = 3,
			SoInteresting = 4,
			WellDone = 5,
			Wonderful = 6,
			Wow = 7,
			YesYes = 8,
			YoureGreat = 9
		}

		public enum GreetingOp
		{
			Hello = 0,
			Goodbye = 1
		}

#if UNITY_EDITOR
		[ContextMenu(nameof(AssignObject))]
		void AssignObject()
		{
			actionSounds = LoadSource.LoadAllAssetAtPath<AudioClip>("Assets/SCNLib/Audio default/Audio/Sound effect/Action sound");
			characterSpecialVoices = LoadSource.LoadAllAssetAtPath<AudioClip>("Assets/SCNLib/Audio default/Audio/Sound effect/Character special");
			happyVoices = LoadSource.LoadAllAssetAtPath<AudioClip>("Assets/SCNLib/Audio default/Audio/Sound effect/Emotion happy voice");
			greetingVoices = LoadSource.LoadAllAssetAtPath<AudioClip>("Assets/SCNLib/Audio default/Audio/Sound effect/Greeting");
        }
#endif
	}
}