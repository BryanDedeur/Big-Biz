﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: UIElement that responds to VR hands and generates UnityEvents
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;


using UnityEngine.EventSystems;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class UIElement : MonoBehaviour
	{

        public UnityEvent onClick;
        //public UnityString onClickString;
        private Selectable selectable;

        public CustomEvents.UnityEventHand onHandClick;

        protected Hand currentHand;

		//-------------------------------------------------
		protected virtual void Awake()
		{
			Button button = GetComponent<Button>();
			if ( button )
			{
				button.onClick.AddListener( OnButtonClick );
			}
		}


		//-------------------------------------------------
		protected virtual void OnHandHoverBegin( Hand hand )
		{
			currentHand = hand;
			InputModule.instance.HoverBegin( gameObject );
			ControllerButtonHints.ShowButtonHint( hand, hand.uiInteractAction);
		}


        //-------------------------------------------------
        protected virtual void OnHandHoverEnd( Hand hand )
		{
			InputModule.instance.HoverEnd( gameObject );
			ControllerButtonHints.HideButtonHint( hand, hand.uiInteractAction);
			currentHand = null;
		}


        //-------------------------------------------------
        protected virtual void HandHoverUpdate( Hand hand )
		{
			if ( hand.uiInteractAction != null && hand.uiInteractAction.GetStateDown(hand.handType) )
			{
				InputModule.instance.Submit( gameObject );
				ControllerButtonHints.HideButtonHint( hand, hand.uiInteractAction);
			}
		}


        //-------------------------------------------------
        protected virtual void OnButtonClick()
		{
			onHandClick.Invoke( currentHand );
		}

        public void OnPointerClicked()
        {
            onClick.Invoke();
            Text text = GetComponentInChildren<Text>();
            if (text != null)
            {
                //onClickString.Invoke(EnumString.RemoveSpaces(text.text));
            }
        }


        void Update()
        {

        }

        public void onPointerIn()
        {
            if (selectable != null)
            {
                selectable.Select();
            }
        }

        public void onPointerOut()
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

    }


#if UNITY_EDITOR
	//-------------------------------------------------------------------------
	[UnityEditor.CustomEditor( typeof( UIElement ) )]
	public class UIElementEditor : UnityEditor.Editor
	{
		//-------------------------------------------------
		// Custom Inspector GUI allows us to click from within the UI
		//-------------------------------------------------
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			UIElement uiElement = (UIElement)target;
			if ( GUILayout.Button( "Click" ) )
			{
				InputModule.instance.Submit( uiElement.gameObject );
			}
		}
	}
#endif
}
