//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class RenderModelChangerUI : UIElement
    {
        public GameObject leftPrefab;
        public GameObject rightPrefab;

		protected SkeletonUIOptions ui;

        protected override void Awake()
        {
            base.Awake();

            ui = this.GetComponentInParent<SkeletonUIOptions>();
        }

        protected override void OnButtonClick()
        {
            base.OnButtonClick();

            if (ui != null)
            {
				// Code to check various stats (money maybe?)

				// Code to spawn employee
				GameObject.CreatePrimitive(PrimitiveType.Cube);

				// Old code, can get rid of probably
				ui.SetRenderModel(this);
            }
        }
    }
}