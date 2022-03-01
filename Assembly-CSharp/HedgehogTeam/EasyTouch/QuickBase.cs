using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048DB RID: 18651
	public class QuickBase : MonoBehaviour
	{
		// Token: 0x0601AD84 RID: 109956 RVA: 0x00841A30 File Offset: 0x0083FE30
		private void Awake()
		{
			this.cachedRigidBody = base.GetComponent<Rigidbody>();
			if (this.cachedRigidBody)
			{
				this.isKinematic = this.cachedRigidBody.isKinematic;
			}
			this.cachedRigidBody2D = base.GetComponent<Rigidbody2D>();
			if (this.cachedRigidBody2D)
			{
				this.isKinematic2D = this.cachedRigidBody2D.isKinematic;
			}
		}

		// Token: 0x0601AD85 RID: 109957 RVA: 0x00841A98 File Offset: 0x0083FE98
		public virtual void Start()
		{
			EasyTouch.SetEnableAutoSelect(true);
			this.realType = QuickBase.GameObjectType.Obj_3D;
			if (base.GetComponent<Collider>())
			{
				this.realType = QuickBase.GameObjectType.Obj_3D;
			}
			else if (base.GetComponent<Collider2D>())
			{
				this.realType = QuickBase.GameObjectType.Obj_2D;
			}
			else if (base.GetComponent<CanvasRenderer>())
			{
				this.realType = QuickBase.GameObjectType.UI;
			}
			QuickBase.GameObjectType gameObjectType = this.realType;
			if (gameObjectType != QuickBase.GameObjectType.Obj_3D)
			{
				if (gameObjectType != QuickBase.GameObjectType.Obj_2D)
				{
					if (gameObjectType == QuickBase.GameObjectType.UI)
					{
						EasyTouch.instance.enableUIMode = true;
						EasyTouch.SetUICompatibily(false);
					}
				}
				else
				{
					EasyTouch.SetEnable2DCollider(true);
					LayerMask layerMask = EasyTouch.Get2DPickableLayer();
					layerMask |= 1 << base.gameObject.layer;
					EasyTouch.Set2DPickableLayer(layerMask);
				}
			}
			else
			{
				LayerMask layerMask = EasyTouch.Get3DPickableLayer();
				layerMask |= 1 << base.gameObject.layer;
				EasyTouch.Set3DPickableLayer(layerMask);
			}
			if (this.enablePickOverUI)
			{
				EasyTouch.instance.enableUIMode = true;
				EasyTouch.SetUICompatibily(false);
			}
		}

		// Token: 0x0601AD86 RID: 109958 RVA: 0x00841BB6 File Offset: 0x0083FFB6
		public virtual void OnEnable()
		{
		}

		// Token: 0x0601AD87 RID: 109959 RVA: 0x00841BB8 File Offset: 0x0083FFB8
		public virtual void OnDisable()
		{
		}

		// Token: 0x0601AD88 RID: 109960 RVA: 0x00841BBC File Offset: 0x0083FFBC
		protected Vector3 GetInfluencedAxis()
		{
			Vector3 zero = Vector3.zero;
			switch (this.axesAction)
			{
			case QuickBase.AffectedAxesAction.X:
				zero..ctor(1f, 0f, 0f);
				break;
			case QuickBase.AffectedAxesAction.Y:
				zero..ctor(0f, 1f, 0f);
				break;
			case QuickBase.AffectedAxesAction.Z:
				zero..ctor(0f, 0f, 1f);
				break;
			case QuickBase.AffectedAxesAction.XY:
				zero..ctor(1f, 1f, 0f);
				break;
			case QuickBase.AffectedAxesAction.XZ:
				zero..ctor(1f, 0f, 1f);
				break;
			case QuickBase.AffectedAxesAction.YZ:
				zero..ctor(0f, 1f, 1f);
				break;
			case QuickBase.AffectedAxesAction.XYZ:
				zero..ctor(1f, 1f, 1f);
				break;
			}
			return zero;
		}

		// Token: 0x0601AD89 RID: 109961 RVA: 0x00841CBC File Offset: 0x008400BC
		protected void DoDirectAction(float value)
		{
			Vector3 influencedAxis = this.GetInfluencedAxis();
			switch (this.directAction)
			{
			case QuickBase.DirectAction.Rotate:
				base.transform.Rotate(influencedAxis * value, 0);
				break;
			case QuickBase.DirectAction.RotateLocal:
				base.transform.Rotate(influencedAxis * value, 1);
				break;
			case QuickBase.DirectAction.Translate:
				if (this.directCharacterController == null)
				{
					base.transform.Translate(influencedAxis * value, 0);
				}
				else
				{
					Vector3 vector = influencedAxis * value;
					this.directCharacterController.Move(vector);
				}
				break;
			case QuickBase.DirectAction.TranslateLocal:
				if (this.directCharacterController == null)
				{
					base.transform.Translate(influencedAxis * value, 1);
				}
				else
				{
					Vector3 vector2 = this.directCharacterController.transform.TransformDirection(influencedAxis) * value;
					this.directCharacterController.Move(vector2);
				}
				break;
			case QuickBase.DirectAction.Scale:
				base.transform.localScale += influencedAxis * value;
				break;
			}
		}

		// Token: 0x0601AD8A RID: 109962 RVA: 0x00841DE0 File Offset: 0x008401E0
		public void EnabledQuickComponent(string quickActionName)
		{
			QuickBase[] components = base.GetComponents<QuickBase>();
			foreach (QuickBase quickBase in components)
			{
				if (quickBase.quickActionName == quickActionName)
				{
					quickBase.enabled = true;
				}
			}
		}

		// Token: 0x0601AD8B RID: 109963 RVA: 0x00841E28 File Offset: 0x00840228
		public void DisabledQuickComponent(string quickActionName)
		{
			QuickBase[] components = base.GetComponents<QuickBase>();
			foreach (QuickBase quickBase in components)
			{
				if (quickBase.quickActionName == quickActionName)
				{
					quickBase.enabled = false;
				}
			}
		}

		// Token: 0x0601AD8C RID: 109964 RVA: 0x00841E70 File Offset: 0x00840270
		public void DisabledAllSwipeExcepted(string quickActionName)
		{
			QuickSwipe[] array = Object.FindObjectsOfType(typeof(QuickSwipe)) as QuickSwipe[];
			foreach (QuickSwipe quickSwipe in array)
			{
				if (quickSwipe.quickActionName != quickActionName || (quickSwipe.quickActionName == quickActionName && quickSwipe.gameObject != base.gameObject))
				{
					quickSwipe.enabled = false;
				}
			}
		}

		// Token: 0x04012AD8 RID: 76504
		public string quickActionName;

		// Token: 0x04012AD9 RID: 76505
		public bool isMultiTouch;

		// Token: 0x04012ADA RID: 76506
		public bool is2Finger;

		// Token: 0x04012ADB RID: 76507
		public bool isOnTouch;

		// Token: 0x04012ADC RID: 76508
		public bool enablePickOverUI;

		// Token: 0x04012ADD RID: 76509
		public bool resetPhysic;

		// Token: 0x04012ADE RID: 76510
		public QuickBase.DirectAction directAction;

		// Token: 0x04012ADF RID: 76511
		public QuickBase.AffectedAxesAction axesAction;

		// Token: 0x04012AE0 RID: 76512
		public float sensibility = 1f;

		// Token: 0x04012AE1 RID: 76513
		public CharacterController directCharacterController;

		// Token: 0x04012AE2 RID: 76514
		public bool inverseAxisValue;

		// Token: 0x04012AE3 RID: 76515
		protected Rigidbody cachedRigidBody;

		// Token: 0x04012AE4 RID: 76516
		protected bool isKinematic;

		// Token: 0x04012AE5 RID: 76517
		protected Rigidbody2D cachedRigidBody2D;

		// Token: 0x04012AE6 RID: 76518
		protected bool isKinematic2D;

		// Token: 0x04012AE7 RID: 76519
		protected QuickBase.GameObjectType realType;

		// Token: 0x04012AE8 RID: 76520
		protected int fingerIndex = -1;

		// Token: 0x020048DC RID: 18652
		protected enum GameObjectType
		{
			// Token: 0x04012AEA RID: 76522
			Auto,
			// Token: 0x04012AEB RID: 76523
			Obj_3D,
			// Token: 0x04012AEC RID: 76524
			Obj_2D,
			// Token: 0x04012AED RID: 76525
			UI
		}

		// Token: 0x020048DD RID: 18653
		public enum DirectAction
		{
			// Token: 0x04012AEF RID: 76527
			None,
			// Token: 0x04012AF0 RID: 76528
			Rotate,
			// Token: 0x04012AF1 RID: 76529
			RotateLocal,
			// Token: 0x04012AF2 RID: 76530
			Translate,
			// Token: 0x04012AF3 RID: 76531
			TranslateLocal,
			// Token: 0x04012AF4 RID: 76532
			Scale
		}

		// Token: 0x020048DE RID: 18654
		public enum AffectedAxesAction
		{
			// Token: 0x04012AF6 RID: 76534
			X,
			// Token: 0x04012AF7 RID: 76535
			Y,
			// Token: 0x04012AF8 RID: 76536
			Z,
			// Token: 0x04012AF9 RID: 76537
			XY,
			// Token: 0x04012AFA RID: 76538
			XZ,
			// Token: 0x04012AFB RID: 76539
			YZ,
			// Token: 0x04012AFC RID: 76540
			XYZ
		}
	}
}
