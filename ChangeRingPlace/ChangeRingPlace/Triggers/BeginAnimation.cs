using ChangeRingPlace.Animations.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChangeRingPlace.Triggers
{
    public class BeginAnimation : TriggerAction<VisualElement>
    {
        public AnimationBase Animation { get; set; }

        protected override async void Invoke(VisualElement sender)
        {
            if (Animation != null)
                await Animation.Begin();
        }
    }
}
