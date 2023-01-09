using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using SCN.Common;
using DG.Tweening;
using SCN.Audio;

namespace SCN.UIExtend
{
	[RequireComponent(typeof(EventTrigger))]
	[RequireComponent(typeof(Image))]
	public class CustomButton : MonoBehaviour
	{
		public static System.Action<CustomButton> OnClickBtn;

		EventTrigger et;
		Image image;

		[Tooltip("Hieu ung scale to ra khi bam vao")]
		[SerializeField] bool scaleWhenClick = true;
		[Tooltip("Hieu ung auto scale to ra, nho lai")]
		[SerializeField] bool scaleLoop = false;
		[Tooltip("Khi bam button, Tutorial se auto bi Kill")]
		[SerializeField] bool stopTutorial = true;
		[Tooltip("Khi bam button, se co am thanh bam nut")]
		[SerializeField] bool playSound = true;

		[Space(10)]

		[SerializeField] UnityEvent OnClick;
		[SerializeField] UnityEvent OnPointerDown;
		[SerializeField] UnityEvent OnPointerUp;

		Vector3 scale;
		Tweener currentTweener;

		const float scaleCoeff = 1.2f;

		public bool ScaleWhenClick 
		{
			get => scaleWhenClick;
			set => scaleWhenClick = value;
		}

		public bool ScaleLoop
		{
			get => scaleLoop;
			set => scaleLoop = value;
		}

		private void Awake()
		{
			et = GetComponent<EventTrigger>();
			image = GetComponent<Image>();

			Master.AddEventTriggerListener(et, EventTriggerType.PointerClick
				, Callback_OnPointerClick);

			Master.AddEventTriggerListener(et, EventTriggerType.PointerDown
				, Callback_OnPointerDown);

			Master.AddEventTriggerListener(et, EventTriggerType.PointerUp
				, Callback_OnPointerUp);
		}

		private void Start()
		{
			scale = transform.localScale;

			if (scaleLoop)
			{
				transform.localScale = scale * scaleCoeff;
				ScaleBtnLoop();
			}
		}

		public bool Interactable
		{
			get => image.raycastTarget;
			set => image.raycastTarget = value;
		}

		public void AddListener(UnityAction call)
		{
			OnClick.AddListener(call);
		}

		public void RemoveListener(UnityAction call)
		{
			OnClick.RemoveListener(call);
		}

		public void RemoveAllListeners()
		{
			OnClick.RemoveAllListeners();
		}

		public void InvokeManual()
		{
			OnClick?.Invoke();
		}

		void Callback_OnPointerClick(BaseEventData data)
		{
			OnClickBtn?.Invoke(this);

			if (stopTutorial)
			{
				SCN.Tutorial.TutorialManager.Instance.Stop();
			}
			if (playSound)
			{
				AudioGlobal.Instance.PlayActionSound(AudioGlobal.ActionOp.Btn);
			}

			OnClick?.Invoke();
		}

		void Callback_OnPointerDown(BaseEventData data)
		{
			if (ScaleWhenClick)
			{
				DOTweenManager.Instance.KillTween(currentTweener);
				currentTweener = DOTweenManager.Instance.TweenScaleTime(
					transform, scale * scaleCoeff, 0.25f).SetEase(Ease.OutBack);
			}
		}

		void Callback_OnPointerUp(BaseEventData data)
		{
			if (scaleLoop)
			{
				ScaleBtnLoop();
			}
			else if (ScaleWhenClick)
			{
				DOTweenManager.Instance.KillTween(currentTweener);
				currentTweener = DOTweenManager.Instance.TweenScaleTime(transform, scale, 0.1f);
			}
		}

		void ScaleBtnLoop()
		{
			DOTweenManager.Instance.KillTween(currentTweener);
			currentTweener = DOTweenManager.Instance.TweenScaleTime(transform
				, scale * 1.2f, scale, 0.4f).SetLoops(-1, LoopType.Yoyo);
		}
	}
}