using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCN.Tutorial
{
	[CreateAssetMenu(fileName = "Tutorial setting", menuName = "SCN/Scriptable Objects/Tutorial setting")]
	public class TutorialSettings : ScriptableObject
	{
		[Header("Setings")]

		[Tooltip("Layer cua ban tay")]
		[SerializeField] string sortingLayer;
		[Tooltip("Layer cua ban tay")]
		[SerializeField] int orderInLayer;

		[Space(10)]
		[SerializeField] float delayStartTime = 3;
		[SerializeField] float noReactTime = 5;

		[SerializeField] float pointerVelocity = 7;

		public string SortingLayer => sortingLayer;
		public int OrderInLayer => orderInLayer;

		public float DelayStartTime
		{
			get => delayStartTime;
			set => delayStartTime = value;
		}

		public float NoReactTime
		{
			get => noReactTime;
			set => noReactTime = value;
		}

		public float PointerVelocity
		{
			get => pointerVelocity;
			set => pointerVelocity = value;
		}
	}
}