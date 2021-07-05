using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARApp.Common.Views
{
    public class ToggleButton : MonoBehaviour
    {
        [SerializeField]
        private Color activeColor;
        [SerializeField]
        private Color disableColor;
        [SerializeField]
        private Button button;
        [SerializeField]
        private Image targetGraphic;

        public IObservable<Unit> OnClickedStream => button.OnClickAsObservable();


        public void Awake()
        {
            Debug.Assert(targetGraphic, "Require target graphic for toggle!", this);
            Debug.Assert(button, "Require button for toggle!", this);
        }

        public void ChangeToggle(bool active)
        {
            targetGraphic.color = active ? activeColor : disableColor;
        }
    }

}
