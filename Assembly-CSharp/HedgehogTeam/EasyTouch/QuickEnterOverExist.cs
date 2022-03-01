using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048E3 RID: 18659
	[AddComponentMenu("EasyTouch/Quick Enter-Over-Exit")]
	public class QuickEnterOverExist : QuickBase
	{
		// Token: 0x0601AD9E RID: 109982 RVA: 0x0084259C File Offset: 0x0084099C
		public QuickEnterOverExist()
		{
			this.quickActionName = "QuickEnterOverExit" + base.GetInstanceID().ToString();
		}

		// Token: 0x0601AD9F RID: 109983 RVA: 0x008425E0 File Offset: 0x008409E0
		private void Awake()
		{
			for (int i = 0; i < 100; i++)
			{
				this.fingerOver[i] = false;
			}
		}

		// Token: 0x0601ADA0 RID: 109984 RVA: 0x00842609 File Offset: 0x00840A09
		public override void OnEnable()
		{
			base.OnEnable();
			EasyTouch.On_TouchDown += this.On_TouchDown;
			EasyTouch.On_TouchUp += this.On_TouchUp;
		}

		// Token: 0x0601ADA1 RID: 109985 RVA: 0x00842633 File Offset: 0x00840A33
		public override void OnDisable()
		{
			base.OnDisable();
			this.UnsubscribeEvent();
		}

		// Token: 0x0601ADA2 RID: 109986 RVA: 0x00842641 File Offset: 0x00840A41
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x0601ADA3 RID: 109987 RVA: 0x00842649 File Offset: 0x00840A49
		private void UnsubscribeEvent()
		{
			EasyTouch.On_TouchDown -= this.On_TouchDown;
			EasyTouch.On_TouchUp -= this.On_TouchUp;
		}

		// Token: 0x0601ADA4 RID: 109988 RVA: 0x00842670 File Offset: 0x00840A70
		private void On_TouchDown(Gesture gesture)
		{
			if (this.realType != QuickBase.GameObjectType.UI)
			{
				if ((!this.enablePickOverUI && gesture.GetCurrentFirstPickedUIElement(false) == null) || this.enablePickOverUI)
				{
					if (gesture.GetCurrentPickedObject(false) == base.gameObject)
					{
						if (!this.fingerOver[gesture.fingerIndex] && ((!this.isOnTouch && !this.isMultiTouch) || this.isMultiTouch))
						{
							this.fingerOver[gesture.fingerIndex] = true;
							this.onTouchEnter.Invoke(gesture);
							this.isOnTouch = true;
						}
						else if (this.fingerOver[gesture.fingerIndex])
						{
							this.onTouchOver.Invoke(gesture);
						}
					}
					else if (this.fingerOver[gesture.fingerIndex])
					{
						this.fingerOver[gesture.fingerIndex] = false;
						this.onTouchExit.Invoke(gesture);
						if (!this.isMultiTouch)
						{
							this.isOnTouch = false;
						}
					}
				}
				else if (gesture.GetCurrentPickedObject(false) == base.gameObject && !this.enablePickOverUI && gesture.GetCurrentFirstPickedUIElement(false) != null && this.fingerOver[gesture.fingerIndex])
				{
					this.fingerOver[gesture.fingerIndex] = false;
					this.onTouchExit.Invoke(gesture);
					if (!this.isMultiTouch)
					{
						this.isOnTouch = false;
					}
				}
			}
			else if (gesture.GetCurrentFirstPickedUIElement(false) == base.gameObject)
			{
				if (!this.fingerOver[gesture.fingerIndex] && ((!this.isOnTouch && !this.isMultiTouch) || this.isMultiTouch))
				{
					this.fingerOver[gesture.fingerIndex] = true;
					this.onTouchEnter.Invoke(gesture);
					this.isOnTouch = true;
				}
				else if (this.fingerOver[gesture.fingerIndex])
				{
					this.onTouchOver.Invoke(gesture);
				}
			}
			else if (this.fingerOver[gesture.fingerIndex])
			{
				this.fingerOver[gesture.fingerIndex] = false;
				this.onTouchExit.Invoke(gesture);
				if (!this.isMultiTouch)
				{
					this.isOnTouch = false;
				}
			}
		}

		// Token: 0x0601ADA5 RID: 109989 RVA: 0x008428CF File Offset: 0x00840CCF
		private void On_TouchUp(Gesture gesture)
		{
			if (this.fingerOver[gesture.fingerIndex])
			{
				this.fingerOver[gesture.fingerIndex] = false;
				this.onTouchExit.Invoke(gesture);
				if (!this.isMultiTouch)
				{
					this.isOnTouch = false;
				}
			}
		}

		// Token: 0x04012B04 RID: 76548
		[SerializeField]
		public QuickEnterOverExist.OnTouchEnter onTouchEnter;

		// Token: 0x04012B05 RID: 76549
		[SerializeField]
		public QuickEnterOverExist.OnTouchOver onTouchOver;

		// Token: 0x04012B06 RID: 76550
		[SerializeField]
		public QuickEnterOverExist.OnTouchExit onTouchExit;

		// Token: 0x04012B07 RID: 76551
		private bool[] fingerOver = new bool[100];

		// Token: 0x020048E4 RID: 18660
		[Serializable]
		public class OnTouchEnter : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048E5 RID: 18661
		[Serializable]
		public class OnTouchOver : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048E6 RID: 18662
		[Serializable]
		public class OnTouchExit : UnityEvent<Gesture>
		{
		}
	}
}
