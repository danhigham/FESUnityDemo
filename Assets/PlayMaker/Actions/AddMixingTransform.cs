﻿// (c) copyright Hutong Games, LLC 2010-2011. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Animation)]
	[Tooltip("Play an animation on a subset of the hierarchy. E.g., A waving animation on the upper body.")]
	public class AddMixingTransform : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Animation))]
		[Tooltip("The GameObject playing the animation.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Tooltip("The name of the animation to mix. NOTE: The animation should already be added to the Animation Component on the GameObject.")]
		public FsmString animationName;

		[RequiredField]
		[Tooltip("The mixing transform. E.g., root/upper_body/left_shoulder")]
		public FsmString transfrom;

		[Tooltip("If recursive is true all children of the mix transform will also be animated.")]
		public FsmBool recursive;

		public override void Reset()
		{
			gameObject = null;
			animationName = "";
			transfrom = "";
			recursive = true;
		}

		public override void OnEnter()
		{
			DoAddMixingTransform();
			
			Finish();
		}

		void DoAddMixingTransform()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null || go.animation == null)
			{
				return;
			}

			var animClip = go.animation[animationName.Value];

			if (animClip == null)
			{
				return;
			}

			var mixingTransform = go.transform.Find(transfrom.Value);
			animClip.AddMixingTransform(mixingTransform, recursive.Value);
		}
	}
}