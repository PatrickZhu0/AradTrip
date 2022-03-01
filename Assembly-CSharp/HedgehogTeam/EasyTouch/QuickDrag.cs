using System;
using UnityEngine;
using UnityEngine.Events;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048DF RID: 18655
	[AddComponentMenu("EasyTouch/Quick Drag")]
	public class QuickDrag : QuickBase
	{
		// Token: 0x0601AD8D RID: 109965 RVA: 0x00841EEC File Offset: 0x008402EC
		public QuickDrag()
		{
			this.quickActionName = "QuickDrag" + base.GetInstanceID().ToString();
			this.axesAction = QuickBase.AffectedAxesAction.XY;
		}

		// Token: 0x0601AD8E RID: 109966 RVA: 0x00841F2C File Offset: 0x0084032C
		public override void OnEnable()
		{
			base.OnEnable();
			EasyTouch.On_TouchStart += this.On_TouchStart;
			EasyTouch.On_TouchDown += this.On_TouchDown;
			EasyTouch.On_TouchUp += this.On_TouchUp;
			EasyTouch.On_Drag += this.On_Drag;
			EasyTouch.On_DragStart += this.On_DragStart;
			EasyTouch.On_DragEnd += this.On_DragEnd;
		}

		// Token: 0x0601AD8F RID: 109967 RVA: 0x00841FA5 File Offset: 0x008403A5
		public override void OnDisable()
		{
			base.OnDisable();
			this.UnsubscribeEvent();
		}

		// Token: 0x0601AD90 RID: 109968 RVA: 0x00841FB3 File Offset: 0x008403B3
		private void OnDestroy()
		{
			this.UnsubscribeEvent();
		}

		// Token: 0x0601AD91 RID: 109969 RVA: 0x00841FBC File Offset: 0x008403BC
		private void UnsubscribeEvent()
		{
			EasyTouch.On_TouchStart -= this.On_TouchStart;
			EasyTouch.On_TouchDown -= this.On_TouchDown;
			EasyTouch.On_TouchUp -= this.On_TouchUp;
			EasyTouch.On_Drag -= this.On_Drag;
			EasyTouch.On_DragStart -= this.On_DragStart;
			EasyTouch.On_DragEnd -= this.On_DragEnd;
		}

		// Token: 0x0601AD92 RID: 109970 RVA: 0x0084202F File Offset: 0x0084042F
		private void OnCollisionEnter()
		{
			if (this.isStopOncollisionEnter && this.isOnDrag)
			{
				this.StopDrag();
			}
		}

		// Token: 0x0601AD93 RID: 109971 RVA: 0x00842050 File Offset: 0x00840450
		private void On_TouchStart(Gesture gesture)
		{
			if (this.realType == QuickBase.GameObjectType.UI && gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)) && this.fingerIndex == -1)
			{
				this.fingerIndex = gesture.fingerIndex;
				base.transform.SetAsLastSibling();
				this.onDragStart.Invoke(gesture);
				this.isOnDrag = true;
			}
		}

		// Token: 0x0601AD94 RID: 109972 RVA: 0x008420DC File Offset: 0x008404DC
		private void On_TouchDown(Gesture gesture)
		{
			if (this.isOnDrag && this.fingerIndex == gesture.fingerIndex && this.realType == QuickBase.GameObjectType.UI && gesture.isOverGui && (gesture.pickedUIElement == base.gameObject || gesture.pickedUIElement.transform.IsChildOf(base.transform)))
			{
				base.transform.position += gesture.deltaPosition;
				if (gesture.deltaPosition != Vector2.zero)
				{
					this.onDrag.Invoke(gesture);
				}
				this.lastGesture = gesture;
			}
		}

		// Token: 0x0601AD95 RID: 109973 RVA: 0x00842196 File Offset: 0x00840596
		private void On_TouchUp(Gesture gesture)
		{
			if (this.fingerIndex == gesture.fingerIndex && this.realType == QuickBase.GameObjectType.UI)
			{
				this.lastGesture = gesture;
				this.StopDrag();
			}
		}

		// Token: 0x0601AD96 RID: 109974 RVA: 0x008421C4 File Offset: 0x008405C4
		private void On_DragStart(Gesture gesture)
		{
			if (this.realType != QuickBase.GameObjectType.UI && ((!this.enablePickOverUI && gesture.pickedUIElement == null) || this.enablePickOverUI) && gesture.pickedObject == base.gameObject && !this.isOnDrag)
			{
				this.isOnDrag = true;
				this.fingerIndex = gesture.fingerIndex;
				Vector3 touchToWorldPoint = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position);
				this.deltaPosition = touchToWorldPoint - base.transform.position;
				if (this.resetPhysic)
				{
					if (this.cachedRigidBody)
					{
						this.cachedRigidBody.isKinematic = true;
					}
					if (this.cachedRigidBody2D)
					{
						this.cachedRigidBody2D.isKinematic = true;
					}
				}
				this.onDragStart.Invoke(gesture);
			}
		}

		// Token: 0x0601AD97 RID: 109975 RVA: 0x008422B8 File Offset: 0x008406B8
		private void On_Drag(Gesture gesture)
		{
			if (this.fingerIndex == gesture.fingerIndex && (this.realType == QuickBase.GameObjectType.Obj_2D || this.realType == QuickBase.GameObjectType.Obj_3D) && gesture.pickedObject == base.gameObject && this.fingerIndex == gesture.fingerIndex)
			{
				Vector3 position = gesture.GetTouchToWorldPoint(gesture.pickedObject.transform.position) - this.deltaPosition;
				base.transform.position = this.GetPositionAxes(position);
				if (gesture.deltaPosition != Vector2.zero)
				{
					this.onDrag.Invoke(gesture);
				}
				this.lastGesture = gesture;
			}
		}

		// Token: 0x0601AD98 RID: 109976 RVA: 0x00842371 File Offset: 0x00840771
		private void On_DragEnd(Gesture gesture)
		{
			if (this.fingerIndex == gesture.fingerIndex)
			{
				this.lastGesture = gesture;
				this.StopDrag();
			}
		}

		// Token: 0x0601AD99 RID: 109977 RVA: 0x00842394 File Offset: 0x00840794
		private Vector3 GetPositionAxes(Vector3 position)
		{
			Vector3 result = position;
			switch (this.axesAction)
			{
			case QuickBase.AffectedAxesAction.X:
				result..ctor(position.x, base.transform.position.y, base.transform.position.z);
				break;
			case QuickBase.AffectedAxesAction.Y:
				result..ctor(base.transform.position.x, position.y, base.transform.position.z);
				break;
			case QuickBase.AffectedAxesAction.Z:
				result..ctor(base.transform.position.x, base.transform.position.y, position.z);
				break;
			case QuickBase.AffectedAxesAction.XY:
				result..ctor(position.x, position.y, base.transform.position.z);
				break;
			case QuickBase.AffectedAxesAction.XZ:
				result..ctor(position.x, base.transform.position.y, position.z);
				break;
			case QuickBase.AffectedAxesAction.YZ:
				result..ctor(base.transform.position.x, position.y, position.z);
				break;
			}
			return result;
		}

		// Token: 0x0601AD9A RID: 109978 RVA: 0x00842508 File Offset: 0x00840908
		public void StopDrag()
		{
			this.fingerIndex = -1;
			if (this.resetPhysic)
			{
				if (this.cachedRigidBody)
				{
					this.cachedRigidBody.isKinematic = this.isKinematic;
				}
				if (this.cachedRigidBody2D)
				{
					this.cachedRigidBody2D.isKinematic = this.isKinematic2D;
				}
			}
			this.isOnDrag = false;
			this.onDragEnd.Invoke(this.lastGesture);
		}

		// Token: 0x04012AFD RID: 76541
		[SerializeField]
		public QuickDrag.OnDragStart onDragStart;

		// Token: 0x04012AFE RID: 76542
		[SerializeField]
		public QuickDrag.OnDrag onDrag;

		// Token: 0x04012AFF RID: 76543
		[SerializeField]
		public QuickDrag.OnDragEnd onDragEnd;

		// Token: 0x04012B00 RID: 76544
		public bool isStopOncollisionEnter;

		// Token: 0x04012B01 RID: 76545
		private Vector3 deltaPosition;

		// Token: 0x04012B02 RID: 76546
		private bool isOnDrag;

		// Token: 0x04012B03 RID: 76547
		private Gesture lastGesture;

		// Token: 0x020048E0 RID: 18656
		[Serializable]
		public class OnDragStart : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048E1 RID: 18657
		[Serializable]
		public class OnDrag : UnityEvent<Gesture>
		{
		}

		// Token: 0x020048E2 RID: 18658
		[Serializable]
		public class OnDragEnd : UnityEvent<Gesture>
		{
		}
	}
}
