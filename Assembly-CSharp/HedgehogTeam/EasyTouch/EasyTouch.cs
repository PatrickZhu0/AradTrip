using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048FF RID: 18687
	public class EasyTouch : MonoBehaviour
	{
		// Token: 0x0601ADDC RID: 110044 RVA: 0x00843C5C File Offset: 0x0084205C
		public EasyTouch()
		{
			this.enable = true;
			this.allowUIDetection = true;
			this.enableUIMode = true;
			this.autoUpdatePickedUI = false;
			this.enabledNGuiMode = false;
			this.nGUICameras = new List<Camera>();
			this.autoSelect = true;
			this.touchCameras = new List<ECamera>();
			this.pickableLayers3D = 1;
			this.enable2D = false;
			this.pickableLayers2D = 1;
			this.gesturePriority = EasyTouch.GesturePriority.Tap;
			this.StationaryTolerance = 15f;
			this.longTapTime = 1f;
			this.doubleTapDetection = EasyTouch.DoubleTapDetection.BySystem;
			this.doubleTapTime = 0.3f;
			this.swipeTolerance = 0.85f;
			this.alwaysSendSwipe = false;
			this.enable2FingersGesture = true;
			this.twoFingerPickMethod = EasyTouch.TwoFingerPickMethod.Finger;
			this.enable2FingersSwipe = true;
			this.enablePinch = true;
			this.minPinchLength = 0f;
			this.enableTwist = true;
			this.minTwistAngle = 0f;
			this.enableSimulation = true;
			this.twistKey = 308;
			this.swipeKey = 306;
		}

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x0601ADDD RID: 110045 RVA: 0x00843DD0 File Offset: 0x008421D0
		// (remove) Token: 0x0601ADDE RID: 110046 RVA: 0x00843E04 File Offset: 0x00842204
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TouchCancelHandler On_Cancel;

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x0601ADDF RID: 110047 RVA: 0x00843E38 File Offset: 0x00842238
		// (remove) Token: 0x0601ADE0 RID: 110048 RVA: 0x00843E6C File Offset: 0x0084226C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.Cancel2FingersHandler On_Cancel2Fingers;

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x0601ADE1 RID: 110049 RVA: 0x00843EA0 File Offset: 0x008422A0
		// (remove) Token: 0x0601ADE2 RID: 110050 RVA: 0x00843ED4 File Offset: 0x008422D4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TouchStartHandler On_TouchStart;

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x0601ADE3 RID: 110051 RVA: 0x00843F08 File Offset: 0x00842308
		// (remove) Token: 0x0601ADE4 RID: 110052 RVA: 0x00843F3C File Offset: 0x0084233C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TouchDownHandler On_TouchDown;

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x0601ADE5 RID: 110053 RVA: 0x00843F70 File Offset: 0x00842370
		// (remove) Token: 0x0601ADE6 RID: 110054 RVA: 0x00843FA4 File Offset: 0x008423A4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TouchUpHandler On_TouchUp;

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x0601ADE7 RID: 110055 RVA: 0x00843FD8 File Offset: 0x008423D8
		// (remove) Token: 0x0601ADE8 RID: 110056 RVA: 0x0084400C File Offset: 0x0084240C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.SimpleTapHandler On_SimpleTap;

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x0601ADE9 RID: 110057 RVA: 0x00844040 File Offset: 0x00842440
		// (remove) Token: 0x0601ADEA RID: 110058 RVA: 0x00844074 File Offset: 0x00842474
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.DoubleTapHandler On_DoubleTap;

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x0601ADEB RID: 110059 RVA: 0x008440A8 File Offset: 0x008424A8
		// (remove) Token: 0x0601ADEC RID: 110060 RVA: 0x008440DC File Offset: 0x008424DC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.LongTapStartHandler On_LongTapStart;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x0601ADED RID: 110061 RVA: 0x00844110 File Offset: 0x00842510
		// (remove) Token: 0x0601ADEE RID: 110062 RVA: 0x00844144 File Offset: 0x00842544
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.LongTapHandler On_LongTap;

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x0601ADEF RID: 110063 RVA: 0x00844178 File Offset: 0x00842578
		// (remove) Token: 0x0601ADF0 RID: 110064 RVA: 0x008441AC File Offset: 0x008425AC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.LongTapEndHandler On_LongTapEnd;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x0601ADF1 RID: 110065 RVA: 0x008441E0 File Offset: 0x008425E0
		// (remove) Token: 0x0601ADF2 RID: 110066 RVA: 0x00844214 File Offset: 0x00842614
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.DragStartHandler On_DragStart;

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x0601ADF3 RID: 110067 RVA: 0x00844248 File Offset: 0x00842648
		// (remove) Token: 0x0601ADF4 RID: 110068 RVA: 0x0084427C File Offset: 0x0084267C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.DragHandler On_Drag;

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x0601ADF5 RID: 110069 RVA: 0x008442B0 File Offset: 0x008426B0
		// (remove) Token: 0x0601ADF6 RID: 110070 RVA: 0x008442E4 File Offset: 0x008426E4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.DragEndHandler On_DragEnd;

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x0601ADF7 RID: 110071 RVA: 0x00844318 File Offset: 0x00842718
		// (remove) Token: 0x0601ADF8 RID: 110072 RVA: 0x0084434C File Offset: 0x0084274C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.SwipeStartHandler On_SwipeStart;

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x0601ADF9 RID: 110073 RVA: 0x00844380 File Offset: 0x00842780
		// (remove) Token: 0x0601ADFA RID: 110074 RVA: 0x008443B4 File Offset: 0x008427B4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.SwipeHandler On_Swipe;

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x0601ADFB RID: 110075 RVA: 0x008443E8 File Offset: 0x008427E8
		// (remove) Token: 0x0601ADFC RID: 110076 RVA: 0x0084441C File Offset: 0x0084281C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.SwipeEndHandler On_SwipeEnd;

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x0601ADFD RID: 110077 RVA: 0x00844450 File Offset: 0x00842850
		// (remove) Token: 0x0601ADFE RID: 110078 RVA: 0x00844484 File Offset: 0x00842884
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TouchStart2FingersHandler On_TouchStart2Fingers;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x0601ADFF RID: 110079 RVA: 0x008444B8 File Offset: 0x008428B8
		// (remove) Token: 0x0601AE00 RID: 110080 RVA: 0x008444EC File Offset: 0x008428EC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TouchDown2FingersHandler On_TouchDown2Fingers;

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x0601AE01 RID: 110081 RVA: 0x00844520 File Offset: 0x00842920
		// (remove) Token: 0x0601AE02 RID: 110082 RVA: 0x00844554 File Offset: 0x00842954
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TouchUp2FingersHandler On_TouchUp2Fingers;

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x0601AE03 RID: 110083 RVA: 0x00844588 File Offset: 0x00842988
		// (remove) Token: 0x0601AE04 RID: 110084 RVA: 0x008445BC File Offset: 0x008429BC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.SimpleTap2FingersHandler On_SimpleTap2Fingers;

		// Token: 0x1400004F RID: 79
		// (add) Token: 0x0601AE05 RID: 110085 RVA: 0x008445F0 File Offset: 0x008429F0
		// (remove) Token: 0x0601AE06 RID: 110086 RVA: 0x00844624 File Offset: 0x00842A24
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.DoubleTap2FingersHandler On_DoubleTap2Fingers;

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x0601AE07 RID: 110087 RVA: 0x00844658 File Offset: 0x00842A58
		// (remove) Token: 0x0601AE08 RID: 110088 RVA: 0x0084468C File Offset: 0x00842A8C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.LongTapStart2FingersHandler On_LongTapStart2Fingers;

		// Token: 0x14000051 RID: 81
		// (add) Token: 0x0601AE09 RID: 110089 RVA: 0x008446C0 File Offset: 0x00842AC0
		// (remove) Token: 0x0601AE0A RID: 110090 RVA: 0x008446F4 File Offset: 0x00842AF4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.LongTap2FingersHandler On_LongTap2Fingers;

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x0601AE0B RID: 110091 RVA: 0x00844728 File Offset: 0x00842B28
		// (remove) Token: 0x0601AE0C RID: 110092 RVA: 0x0084475C File Offset: 0x00842B5C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.LongTapEnd2FingersHandler On_LongTapEnd2Fingers;

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x0601AE0D RID: 110093 RVA: 0x00844790 File Offset: 0x00842B90
		// (remove) Token: 0x0601AE0E RID: 110094 RVA: 0x008447C4 File Offset: 0x00842BC4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TwistHandler On_Twist;

		// Token: 0x14000054 RID: 84
		// (add) Token: 0x0601AE0F RID: 110095 RVA: 0x008447F8 File Offset: 0x00842BF8
		// (remove) Token: 0x0601AE10 RID: 110096 RVA: 0x0084482C File Offset: 0x00842C2C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.TwistEndHandler On_TwistEnd;

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x0601AE11 RID: 110097 RVA: 0x00844860 File Offset: 0x00842C60
		// (remove) Token: 0x0601AE12 RID: 110098 RVA: 0x00844894 File Offset: 0x00842C94
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.PinchHandler On_Pinch;

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x0601AE13 RID: 110099 RVA: 0x008448C8 File Offset: 0x00842CC8
		// (remove) Token: 0x0601AE14 RID: 110100 RVA: 0x008448FC File Offset: 0x00842CFC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.PinchInHandler On_PinchIn;

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x0601AE15 RID: 110101 RVA: 0x00844930 File Offset: 0x00842D30
		// (remove) Token: 0x0601AE16 RID: 110102 RVA: 0x00844964 File Offset: 0x00842D64
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.PinchOutHandler On_PinchOut;

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x0601AE17 RID: 110103 RVA: 0x00844998 File Offset: 0x00842D98
		// (remove) Token: 0x0601AE18 RID: 110104 RVA: 0x008449CC File Offset: 0x00842DCC
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.PinchEndHandler On_PinchEnd;

		// Token: 0x14000059 RID: 89
		// (add) Token: 0x0601AE19 RID: 110105 RVA: 0x00844A00 File Offset: 0x00842E00
		// (remove) Token: 0x0601AE1A RID: 110106 RVA: 0x00844A34 File Offset: 0x00842E34
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.DragStart2FingersHandler On_DragStart2Fingers;

		// Token: 0x1400005A RID: 90
		// (add) Token: 0x0601AE1B RID: 110107 RVA: 0x00844A68 File Offset: 0x00842E68
		// (remove) Token: 0x0601AE1C RID: 110108 RVA: 0x00844A9C File Offset: 0x00842E9C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.Drag2FingersHandler On_Drag2Fingers;

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x0601AE1D RID: 110109 RVA: 0x00844AD0 File Offset: 0x00842ED0
		// (remove) Token: 0x0601AE1E RID: 110110 RVA: 0x00844B04 File Offset: 0x00842F04
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.DragEnd2FingersHandler On_DragEnd2Fingers;

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x0601AE1F RID: 110111 RVA: 0x00844B38 File Offset: 0x00842F38
		// (remove) Token: 0x0601AE20 RID: 110112 RVA: 0x00844B6C File Offset: 0x00842F6C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.SwipeStart2FingersHandler On_SwipeStart2Fingers;

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x0601AE21 RID: 110113 RVA: 0x00844BA0 File Offset: 0x00842FA0
		// (remove) Token: 0x0601AE22 RID: 110114 RVA: 0x00844BD4 File Offset: 0x00842FD4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.Swipe2FingersHandler On_Swipe2Fingers;

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x0601AE23 RID: 110115 RVA: 0x00844C08 File Offset: 0x00843008
		// (remove) Token: 0x0601AE24 RID: 110116 RVA: 0x00844C3C File Offset: 0x0084303C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.SwipeEnd2FingersHandler On_SwipeEnd2Fingers;

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x0601AE25 RID: 110117 RVA: 0x00844C70 File Offset: 0x00843070
		// (remove) Token: 0x0601AE26 RID: 110118 RVA: 0x00844CA4 File Offset: 0x008430A4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.EasyTouchIsReadyHandler On_EasyTouchIsReady;

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x0601AE27 RID: 110119 RVA: 0x00844CD8 File Offset: 0x008430D8
		// (remove) Token: 0x0601AE28 RID: 110120 RVA: 0x00844D0C File Offset: 0x0084310C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.OverUIElementHandler On_OverUIElement;

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x0601AE29 RID: 110121 RVA: 0x00844D40 File Offset: 0x00843140
		// (remove) Token: 0x0601AE2A RID: 110122 RVA: 0x00844D74 File Offset: 0x00843174
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event EasyTouch.UIElementTouchUpHandler On_UIElementTouchUp;

		// Token: 0x170022B9 RID: 8889
		// (get) Token: 0x0601AE2B RID: 110123 RVA: 0x00844DA8 File Offset: 0x008431A8
		public static EasyTouch instance
		{
			get
			{
				if (!EasyTouch._instance)
				{
					EasyTouch._instance = (Object.FindObjectOfType(typeof(EasyTouch)) as EasyTouch);
					if (!EasyTouch._instance)
					{
						GameObject gameObject = new GameObject("Easytouch");
						EasyTouch._instance = gameObject.AddComponent<EasyTouch>();
					}
				}
				return EasyTouch._instance;
			}
		}

		// Token: 0x170022BA RID: 8890
		// (get) Token: 0x0601AE2C RID: 110124 RVA: 0x00844E07 File Offset: 0x00843207
		public static Gesture current
		{
			get
			{
				return EasyTouch.instance._currentGesture;
			}
		}

		// Token: 0x0601AE2D RID: 110125 RVA: 0x00844E13 File Offset: 0x00843213
		private void OnEnable()
		{
			if (Application.isPlaying && Application.isEditor)
			{
				this.Init();
			}
		}

		// Token: 0x0601AE2E RID: 110126 RVA: 0x00844E2F File Offset: 0x0084322F
		private void Awake()
		{
			this.Init();
		}

		// Token: 0x0601AE2F RID: 110127 RVA: 0x00844E38 File Offset: 0x00843238
		private void Start()
		{
			for (int i = 0; i < 100; i++)
			{
				this.singleDoubleTap[i] = new EasyTouch.DoubleTap();
			}
			int num = this.touchCameras.FindIndex((ECamera c) => c.camera == Camera.main);
			if (num < 0)
			{
				this.touchCameras.Add(new ECamera(Camera.main, false));
			}
			if (EasyTouch.On_EasyTouchIsReady != null)
			{
				EasyTouch.On_EasyTouchIsReady();
			}
			this._currentGestures.Add(new Gesture());
		}

		// Token: 0x0601AE30 RID: 110128 RVA: 0x00844ECF File Offset: 0x008432CF
		private void Init()
		{
		}

		// Token: 0x0601AE31 RID: 110129 RVA: 0x00844ED1 File Offset: 0x008432D1
		private void OnDrawGizmos()
		{
		}

		// Token: 0x0601AE32 RID: 110130 RVA: 0x00844ED4 File Offset: 0x008432D4
		private void Update()
		{
			if (this.enable && EasyTouch.instance == this)
			{
				if (Application.isPlaying && Input.touchCount > 0)
				{
					this.enableRemote = true;
				}
				if (Application.isEditor && Input.touchCount == 0)
				{
					this.enableRemote = false;
				}
				int num = this.input.TouchCount();
				if (this.oldTouchCount == 2 && num != 2 && num > 0)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_Cancel2Fingers, Vector2.zero, Vector2.zero, Vector2.zero, 0f, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, 0f);
				}
				this.UpdateTouches(true, num);
				this.twoFinger.oldPickedObject = this.twoFinger.pickedObject;
				if (this.enable2FingersGesture && num == 2)
				{
					this.TwoFinger();
				}
				for (int i = 0; i < 100; i++)
				{
					if (this.fingers[i] != null)
					{
						this.OneFinger(i);
					}
				}
				this.oldTouchCount = num;
			}
		}

		// Token: 0x0601AE33 RID: 110131 RVA: 0x00844FF4 File Offset: 0x008433F4
		private void LateUpdate()
		{
			if (this._currentGestures.Count > 1)
			{
				this._currentGestures.RemoveAt(0);
			}
			else
			{
				this._currentGestures[0] = new Gesture();
			}
			this._currentGesture = this._currentGestures[0];
		}

		// Token: 0x0601AE34 RID: 110132 RVA: 0x00845048 File Offset: 0x00843448
		private void UpdateTouches(bool realTouch, int touchCount)
		{
			this.fingers.CopyTo(this.tmpArray, 0);
			if (realTouch || this.enableRemote)
			{
				this.ResetTouches();
				for (int i = 0; i < touchCount; i++)
				{
					Touch touch = Input.GetTouch(i);
					int num = 0;
					while (num < 100 && this.fingers[i] == null)
					{
						if (this.tmpArray[num] != null && this.tmpArray[num].fingerIndex == touch.fingerId)
						{
							this.fingers[i] = this.tmpArray[num];
						}
						num++;
					}
					if (this.fingers[i] == null)
					{
						this.fingers[i] = new Finger();
						this.fingers[i].fingerIndex = touch.fingerId;
						this.fingers[i].gesture = EasyTouch.GestureType.None;
						this.fingers[i].phase = 0;
					}
					else
					{
						this.fingers[i].phase = touch.phase;
					}
					if (this.fingers[i].phase != null)
					{
						this.fingers[i].deltaPosition = touch.position - this.fingers[i].position;
					}
					else
					{
						this.fingers[i].deltaPosition = Vector2.zero;
					}
					this.fingers[i].position = touch.position;
					this.fingers[i].tapCount = touch.tapCount;
					this.fingers[i].deltaTime = touch.deltaTime;
					this.fingers[i].touchCount = touchCount;
				}
			}
			else
			{
				for (int j = 0; j < touchCount; j++)
				{
					this.fingers[j] = this.input.GetMouseTouch(j, this.fingers[j]);
					this.fingers[j].touchCount = touchCount;
				}
			}
		}

		// Token: 0x0601AE35 RID: 110133 RVA: 0x0084522C File Offset: 0x0084362C
		private void ResetTouches()
		{
			for (int i = 0; i < 100; i++)
			{
				this.fingers[i] = null;
			}
		}

		// Token: 0x0601AE36 RID: 110134 RVA: 0x00845258 File Offset: 0x00843658
		private void OneFinger(int fingerIndex)
		{
			if (this.fingers[fingerIndex].gesture == EasyTouch.GestureType.None)
			{
				if (!this.singleDoubleTap[fingerIndex].inDoubleTap)
				{
					this.singleDoubleTap[fingerIndex].inDoubleTap = true;
					this.singleDoubleTap[fingerIndex].time = 0f;
					this.singleDoubleTap[fingerIndex].count = 1;
				}
				this.fingers[fingerIndex].startTimeAction = Time.realtimeSinceStartup;
				this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Acquisition;
				this.fingers[fingerIndex].startPosition = this.fingers[fingerIndex].position;
				if (this.autoSelect && this.GetPickedGameObject(this.fingers[fingerIndex], false))
				{
					this.fingers[fingerIndex].pickedObject = this.pickedObject.pickedObj;
					this.fingers[fingerIndex].isGuiCamera = this.pickedObject.isGUI;
					this.fingers[fingerIndex].pickedCamera = this.pickedObject.pickedCamera;
				}
				if (this.allowUIDetection)
				{
					this.fingers[fingerIndex].isOverGui = this.IsScreenPositionOverUI(this.fingers[fingerIndex].position);
					this.fingers[fingerIndex].pickedUIElement = this.GetFirstUIElementFromCache();
				}
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_TouchStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
			}
			if (this.singleDoubleTap[fingerIndex].inDoubleTap)
			{
				this.singleDoubleTap[fingerIndex].time += Time.deltaTime;
			}
			this.fingers[fingerIndex].actionTime = Time.realtimeSinceStartup - this.fingers[fingerIndex].startTimeAction;
			if (this.fingers[fingerIndex].phase == 4)
			{
				this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Cancel;
			}
			if (this.fingers[fingerIndex].phase != 3 && this.fingers[fingerIndex].phase != 4)
			{
				if (this.fingers[fingerIndex].phase == 2 && this.fingers[fingerIndex].actionTime >= this.longTapTime && this.fingers[fingerIndex].gesture == EasyTouch.GestureType.Acquisition)
				{
					this.fingers[fingerIndex].gesture = EasyTouch.GestureType.LongTap;
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_LongTapStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
				}
				if (((this.fingers[fingerIndex].gesture == EasyTouch.GestureType.Acquisition || this.fingers[fingerIndex].gesture == EasyTouch.GestureType.LongTap) && this.fingers[fingerIndex].phase == 1 && this.gesturePriority == EasyTouch.GesturePriority.Slips) || ((this.fingers[fingerIndex].gesture == EasyTouch.GestureType.Acquisition || this.fingers[fingerIndex].gesture == EasyTouch.GestureType.LongTap) && !this.FingerInTolerance(this.fingers[fingerIndex]) && this.gesturePriority == EasyTouch.GesturePriority.Tap))
				{
					if (this.fingers[fingerIndex].gesture == EasyTouch.GestureType.LongTap)
					{
						this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Cancel;
						this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_LongTapEnd, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
						this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Acquisition;
					}
					else
					{
						this.fingers[fingerIndex].oldSwipeType = EasyTouch.SwipeDirection.None;
						if (this.fingers[fingerIndex].pickedObject)
						{
							this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Drag;
							this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_DragStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
							if (this.alwaysSendSwipe)
							{
								this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SwipeStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
							}
						}
						else
						{
							this.fingers[fingerIndex].gesture = EasyTouch.GestureType.Swipe;
							this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SwipeStart, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
						}
					}
				}
				EasyTouch.EvtType evtType = EasyTouch.EvtType.None;
				EasyTouch.GestureType gesture = this.fingers[fingerIndex].gesture;
				if (gesture != EasyTouch.GestureType.LongTap)
				{
					if (gesture != EasyTouch.GestureType.Drag)
					{
						if (gesture == EasyTouch.GestureType.Swipe)
						{
							evtType = EasyTouch.EvtType.On_Swipe;
						}
					}
					else
					{
						evtType = EasyTouch.EvtType.On_Drag;
					}
				}
				else
				{
					evtType = EasyTouch.EvtType.On_LongTap;
				}
				EasyTouch.SwipeDirection swipe = this.GetSwipe(new Vector2(0f, 0f), this.fingers[fingerIndex].deltaPosition);
				if (evtType != EasyTouch.EvtType.None)
				{
					this.fingers[fingerIndex].oldSwipeType = swipe;
					this.CreateGesture(fingerIndex, evtType, this.fingers[fingerIndex], swipe, 0f, this.fingers[fingerIndex].deltaPosition);
					if (evtType == EasyTouch.EvtType.On_Drag && this.alwaysSendSwipe)
					{
						this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_Swipe, this.fingers[fingerIndex], swipe, 0f, this.fingers[fingerIndex].deltaPosition);
					}
				}
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_TouchDown, this.fingers[fingerIndex], swipe, 0f, this.fingers[fingerIndex].deltaPosition);
			}
			else
			{
				switch (this.fingers[fingerIndex].gesture)
				{
				case EasyTouch.GestureType.Drag:
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_DragEnd, this.fingers[fingerIndex], this.GetSwipe(this.fingers[fingerIndex].startPosition, this.fingers[fingerIndex].position), (this.fingers[fingerIndex].startPosition - this.fingers[fingerIndex].position).magnitude, this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition);
					if (this.alwaysSendSwipe)
					{
						this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SwipeEnd, this.fingers[fingerIndex], this.GetSwipe(this.fingers[fingerIndex].startPosition, this.fingers[fingerIndex].position), (this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition).magnitude, this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition);
					}
					break;
				case EasyTouch.GestureType.Swipe:
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SwipeEnd, this.fingers[fingerIndex], this.GetSwipe(this.fingers[fingerIndex].startPosition, this.fingers[fingerIndex].position), (this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition).magnitude, this.fingers[fingerIndex].position - this.fingers[fingerIndex].startPosition);
					break;
				case EasyTouch.GestureType.LongTap:
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_LongTapEnd, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
					break;
				case EasyTouch.GestureType.Cancel:
					this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_Cancel, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
					break;
				case EasyTouch.GestureType.Acquisition:
					if (this.doubleTapDetection == EasyTouch.DoubleTapDetection.BySystem)
					{
						if (this.FingerInTolerance(this.fingers[fingerIndex]))
						{
							if (this.fingers[fingerIndex].tapCount < 2)
							{
								this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SimpleTap, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
							}
							else
							{
								this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_DoubleTap, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
							}
						}
					}
					else if (!this.singleDoubleTap[fingerIndex].inWait)
					{
						this.singleDoubleTap[fingerIndex].finger = this.fingers[fingerIndex];
						base.StartCoroutine(this.SingleOrDouble(fingerIndex));
					}
					else
					{
						this.singleDoubleTap[fingerIndex].count++;
					}
					break;
				}
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_TouchUp, this.fingers[fingerIndex], EasyTouch.SwipeDirection.None, 0f, Vector2.zero);
				this.fingers[fingerIndex] = null;
			}
		}

		// Token: 0x0601AE37 RID: 110135 RVA: 0x00845A08 File Offset: 0x00843E08
		private IEnumerator SingleOrDouble(int fingerIndex)
		{
			this.singleDoubleTap[fingerIndex].inWait = true;
			float time2Wait = this.doubleTapTime - this.singleDoubleTap[fingerIndex].finger.actionTime;
			if (time2Wait < 0f)
			{
				time2Wait = 0f;
			}
			yield return new WaitForSeconds(time2Wait);
			if (this.singleDoubleTap[fingerIndex].count < 2)
			{
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_SimpleTap, this.singleDoubleTap[fingerIndex].finger, EasyTouch.SwipeDirection.None, 0f, this.singleDoubleTap[fingerIndex].finger.deltaPosition);
			}
			else
			{
				this.CreateGesture(fingerIndex, EasyTouch.EvtType.On_DoubleTap, this.singleDoubleTap[fingerIndex].finger, EasyTouch.SwipeDirection.None, 0f, this.singleDoubleTap[fingerIndex].finger.deltaPosition);
			}
			this.singleDoubleTap[fingerIndex].Stop();
			base.StopCoroutine("SingleOrDouble");
			yield break;
		}

		// Token: 0x0601AE38 RID: 110136 RVA: 0x00845A2C File Offset: 0x00843E2C
		private void CreateGesture(int touchIndex, EasyTouch.EvtType message, Finger finger, EasyTouch.SwipeDirection swipe, float swipeLength, Vector2 swipeVector)
		{
			bool flag = true;
			if (this.autoUpdatePickedUI && this.allowUIDetection)
			{
				finger.isOverGui = this.IsScreenPositionOverUI(finger.position);
				finger.pickedUIElement = this.GetFirstUIElementFromCache();
			}
			if (this.enabledNGuiMode && message == EasyTouch.EvtType.On_TouchStart)
			{
				finger.isOverGui = (finger.isOverGui || this.IsTouchOverNGui(finger.position, false));
			}
			if (this.enableUIMode || this.enabledNGuiMode)
			{
				flag = !finger.isOverGui;
			}
			Gesture gesture = finger.GetGesture();
			if (this.autoUpdatePickedObject && this.autoSelect && message != EasyTouch.EvtType.On_Drag && message != EasyTouch.EvtType.On_DragEnd && message != EasyTouch.EvtType.On_DragStart)
			{
				if (this.GetPickedGameObject(finger, false))
				{
					gesture.pickedObject = this.pickedObject.pickedObj;
					gesture.pickedCamera = this.pickedObject.pickedCamera;
					gesture.isGuiCamera = this.pickedObject.isGUI;
				}
				else
				{
					gesture.pickedObject = null;
					gesture.pickedCamera = null;
					gesture.isGuiCamera = false;
				}
			}
			gesture.swipe = swipe;
			gesture.swipeLength = swipeLength;
			gesture.swipeVector = swipeVector;
			gesture.deltaPinch = 0f;
			gesture.twistAngle = 0f;
			if (flag)
			{
				this.RaiseEvent(message, gesture);
			}
			else if (finger.isOverGui)
			{
				if (message == EasyTouch.EvtType.On_TouchUp)
				{
					this.RaiseEvent(EasyTouch.EvtType.On_UIElementTouchUp, gesture);
				}
				else
				{
					this.RaiseEvent(EasyTouch.EvtType.On_OverUIElement, gesture);
				}
			}
		}

		// Token: 0x0601AE39 RID: 110137 RVA: 0x00845BBC File Offset: 0x00843FBC
		private void TwoFinger()
		{
			bool flag = false;
			if (this.twoFinger.currentGesture == EasyTouch.GestureType.None)
			{
				if (!this.singleDoubleTap[99].inDoubleTap)
				{
					this.singleDoubleTap[99].inDoubleTap = true;
					this.singleDoubleTap[99].time = 0f;
					this.singleDoubleTap[99].count = 1;
				}
				this.twoFinger.finger0 = this.GetTwoFinger(-1);
				this.twoFinger.finger1 = this.GetTwoFinger(this.twoFinger.finger0);
				this.twoFinger.startTimeAction = Time.realtimeSinceStartup;
				this.twoFinger.currentGesture = EasyTouch.GestureType.Acquisition;
				this.fingers[this.twoFinger.finger0].startPosition = this.fingers[this.twoFinger.finger0].position;
				this.fingers[this.twoFinger.finger1].startPosition = this.fingers[this.twoFinger.finger1].position;
				this.fingers[this.twoFinger.finger0].oldPosition = this.fingers[this.twoFinger.finger0].position;
				this.fingers[this.twoFinger.finger1].oldPosition = this.fingers[this.twoFinger.finger1].position;
				this.twoFinger.oldFingerDistance = Mathf.Abs(Vector2.Distance(this.fingers[this.twoFinger.finger0].position, this.fingers[this.twoFinger.finger1].position));
				this.twoFinger.startPosition = new Vector2((this.fingers[this.twoFinger.finger0].position.x + this.fingers[this.twoFinger.finger1].position.x) / 2f, (this.fingers[this.twoFinger.finger0].position.y + this.fingers[this.twoFinger.finger1].position.y) / 2f);
				this.twoFinger.position = this.twoFinger.startPosition;
				this.twoFinger.oldStartPosition = this.twoFinger.startPosition;
				this.twoFinger.deltaPosition = Vector2.zero;
				this.twoFinger.startDistance = this.twoFinger.oldFingerDistance;
				if (this.autoSelect)
				{
					if (this.GetTwoFingerPickedObject())
					{
						this.twoFinger.pickedObject = this.pickedObject.pickedObj;
						this.twoFinger.pickedCamera = this.pickedObject.pickedCamera;
						this.twoFinger.isGuiCamera = this.pickedObject.isGUI;
					}
					else
					{
						this.twoFinger.ClearPickedObjectData();
					}
				}
				if (this.allowUIDetection)
				{
					if (this.GetTwoFingerPickedUIElement())
					{
						this.twoFinger.pickedUIElement = this.pickedObject.pickedObj;
						this.twoFinger.isOverGui = true;
					}
					else
					{
						this.twoFinger.ClearPickedUIData();
					}
				}
				this.CreateGesture2Finger(EasyTouch.EvtType.On_TouchStart2Fingers, this.twoFinger.startPosition, this.twoFinger.startPosition, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.oldFingerDistance);
			}
			if (this.singleDoubleTap[99].inDoubleTap)
			{
				this.singleDoubleTap[99].time += Time.deltaTime;
			}
			this.twoFinger.timeSinceStartAction = Time.realtimeSinceStartup - this.twoFinger.startTimeAction;
			this.twoFinger.position = new Vector2((this.fingers[this.twoFinger.finger0].position.x + this.fingers[this.twoFinger.finger1].position.x) / 2f, (this.fingers[this.twoFinger.finger0].position.y + this.fingers[this.twoFinger.finger1].position.y) / 2f);
			this.twoFinger.deltaPosition = this.twoFinger.position - this.twoFinger.oldStartPosition;
			this.twoFinger.fingerDistance = Mathf.Abs(Vector2.Distance(this.fingers[this.twoFinger.finger0].position, this.fingers[this.twoFinger.finger1].position));
			if (this.fingers[this.twoFinger.finger0].phase == 4 || this.fingers[this.twoFinger.finger1].phase == 4)
			{
				this.twoFinger.currentGesture = EasyTouch.GestureType.Cancel;
			}
			if (this.fingers[this.twoFinger.finger0].phase != 3 && this.fingers[this.twoFinger.finger1].phase != 3 && this.twoFinger.currentGesture != EasyTouch.GestureType.Cancel)
			{
				if (this.twoFinger.currentGesture == EasyTouch.GestureType.Acquisition && this.twoFinger.timeSinceStartAction >= this.longTapTime && this.FingerInTolerance(this.fingers[this.twoFinger.finger0]) && this.FingerInTolerance(this.fingers[this.twoFinger.finger1]))
				{
					this.twoFinger.currentGesture = EasyTouch.GestureType.LongTap;
					this.CreateGesture2Finger(EasyTouch.EvtType.On_LongTapStart2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
				}
				if (((!this.FingerInTolerance(this.fingers[this.twoFinger.finger0]) || !this.FingerInTolerance(this.fingers[this.twoFinger.finger1])) && this.gesturePriority == EasyTouch.GesturePriority.Tap) || ((this.fingers[this.twoFinger.finger0].phase == 1 || this.fingers[this.twoFinger.finger1].phase == 1) && this.gesturePriority == EasyTouch.GesturePriority.Slips))
				{
					flag = true;
				}
				if (flag && this.twoFinger.currentGesture != EasyTouch.GestureType.Tap)
				{
					Vector2 currentDistance = this.fingers[this.twoFinger.finger0].position - this.fingers[this.twoFinger.finger1].position;
					Vector2 previousDistance = this.fingers[this.twoFinger.finger0].oldPosition - this.fingers[this.twoFinger.finger1].oldPosition;
					float currentDelta = currentDistance.magnitude - previousDistance.magnitude;
					if (this.enable2FingersSwipe)
					{
						float num = Vector2.Dot(this.fingers[this.twoFinger.finger0].deltaPosition.normalized, this.fingers[this.twoFinger.finger1].deltaPosition.normalized);
						if (num > 0f)
						{
							if (this.twoFinger.oldGesture == EasyTouch.GestureType.LongTap)
							{
								this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, false, this.twoFinger.fingerDistance, 0f, 0f);
								this.twoFinger.startTimeAction = Time.realtimeSinceStartup;
							}
							if (this.twoFinger.pickedObject && !this.twoFinger.dragStart && !this.alwaysSendSwipe)
							{
								this.twoFinger.currentGesture = EasyTouch.GestureType.Drag;
								this.CreateGesture2Finger(EasyTouch.EvtType.On_DragStart2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
								this.CreateGesture2Finger(EasyTouch.EvtType.On_SwipeStart2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
								this.twoFinger.dragStart = true;
							}
							else if (!this.twoFinger.pickedObject && !this.twoFinger.swipeStart)
							{
								this.twoFinger.currentGesture = EasyTouch.GestureType.Swipe;
								this.CreateGesture2Finger(EasyTouch.EvtType.On_SwipeStart2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
								this.twoFinger.swipeStart = true;
							}
						}
						else if (num < 0f)
						{
							this.twoFinger.dragStart = false;
							this.twoFinger.swipeStart = false;
						}
						if (this.twoFinger.dragStart)
						{
							this.CreateGesture2Finger(EasyTouch.EvtType.On_Drag2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.oldStartPosition, this.twoFinger.position), 0f, this.twoFinger.deltaPosition, 0f, 0f, this.twoFinger.fingerDistance);
							this.CreateGesture2Finger(EasyTouch.EvtType.On_Swipe2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.oldStartPosition, this.twoFinger.position), 0f, this.twoFinger.deltaPosition, 0f, 0f, this.twoFinger.fingerDistance);
						}
						if (this.twoFinger.swipeStart)
						{
							this.CreateGesture2Finger(EasyTouch.EvtType.On_Swipe2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.oldStartPosition, this.twoFinger.position), 0f, this.twoFinger.deltaPosition, 0f, 0f, this.twoFinger.fingerDistance);
						}
					}
					this.DetectPinch(currentDelta);
					this.DetecTwist(previousDistance, currentDistance, currentDelta);
				}
				else if (this.twoFinger.currentGesture == EasyTouch.GestureType.LongTap)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_LongTap2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
				}
				this.CreateGesture2Finger(EasyTouch.EvtType.On_TouchDown2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.oldStartPosition, this.twoFinger.position), 0f, this.twoFinger.deltaPosition, 0f, 0f, this.twoFinger.fingerDistance);
				this.fingers[this.twoFinger.finger0].oldPosition = this.fingers[this.twoFinger.finger0].position;
				this.fingers[this.twoFinger.finger1].oldPosition = this.fingers[this.twoFinger.finger1].position;
				this.twoFinger.oldFingerDistance = this.twoFinger.fingerDistance;
				this.twoFinger.oldStartPosition = this.twoFinger.position;
				this.twoFinger.oldGesture = this.twoFinger.currentGesture;
			}
			else if (this.twoFinger.currentGesture != EasyTouch.GestureType.Acquisition && this.twoFinger.currentGesture != EasyTouch.GestureType.Tap)
			{
				this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, true, this.twoFinger.fingerDistance, 0f, 0f);
				this.twoFinger.currentGesture = EasyTouch.GestureType.None;
				this.twoFinger.pickedObject = null;
				this.twoFinger.swipeStart = false;
				this.twoFinger.dragStart = false;
			}
			else
			{
				this.twoFinger.currentGesture = EasyTouch.GestureType.Tap;
				this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, true, this.twoFinger.fingerDistance, 0f, 0f);
			}
		}

		// Token: 0x0601AE3A RID: 110138 RVA: 0x00846988 File Offset: 0x00844D88
		private void DetectPinch(float currentDelta)
		{
			if (this.enablePinch)
			{
				if ((Mathf.Abs(this.twoFinger.fingerDistance - this.twoFinger.startDistance) >= this.minPinchLength && this.twoFinger.currentGesture != EasyTouch.GestureType.Pinch) || this.twoFinger.currentGesture == EasyTouch.GestureType.Pinch)
				{
					if (currentDelta != 0f && this.twoFinger.oldGesture == EasyTouch.GestureType.LongTap)
					{
						this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, false, this.twoFinger.fingerDistance, 0f, 0f);
						this.twoFinger.startTimeAction = Time.realtimeSinceStartup;
					}
					this.twoFinger.currentGesture = EasyTouch.GestureType.Pinch;
					if (currentDelta > 0f)
					{
						this.CreateGesture2Finger(EasyTouch.EvtType.On_PinchOut, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.startPosition, this.twoFinger.position), 0f, Vector2.zero, 0f, Mathf.Abs(this.twoFinger.fingerDistance - this.twoFinger.oldFingerDistance), this.twoFinger.fingerDistance);
					}
					if (currentDelta < 0f)
					{
						this.CreateGesture2Finger(EasyTouch.EvtType.On_PinchIn, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.startPosition, this.twoFinger.position), 0f, Vector2.zero, 0f, Mathf.Abs(this.twoFinger.fingerDistance - this.twoFinger.oldFingerDistance), this.twoFinger.fingerDistance);
					}
					if (currentDelta < 0f || currentDelta > 0f)
					{
						this.CreateGesture2Finger(EasyTouch.EvtType.On_Pinch, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, this.GetSwipe(this.twoFinger.startPosition, this.twoFinger.position), 0f, Vector2.zero, 0f, currentDelta, this.twoFinger.fingerDistance);
					}
				}
				this.twoFinger.lastPinch = ((currentDelta <= 0f) ? this.twoFinger.lastPinch : currentDelta);
			}
		}

		// Token: 0x0601AE3B RID: 110139 RVA: 0x00846C40 File Offset: 0x00845040
		private void DetecTwist(Vector2 previousDistance, Vector2 currentDistance, float currentDelta)
		{
			if (this.enableTwist)
			{
				float num = Vector2.Angle(previousDistance, currentDistance);
				if (previousDistance == currentDistance)
				{
					num = 0f;
				}
				if ((Mathf.Abs(num) >= this.minTwistAngle && this.twoFinger.currentGesture != EasyTouch.GestureType.Twist) || this.twoFinger.currentGesture == EasyTouch.GestureType.Twist)
				{
					if (this.twoFinger.oldGesture == EasyTouch.GestureType.LongTap)
					{
						this.CreateStateEnd2Fingers(this.twoFinger.currentGesture, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, false, this.twoFinger.fingerDistance, 0f, 0f);
						this.twoFinger.startTimeAction = Time.realtimeSinceStartup;
					}
					this.twoFinger.currentGesture = EasyTouch.GestureType.Twist;
					if (num != 0f)
					{
						num *= Mathf.Sign(Vector3.Cross(previousDistance, currentDistance).z);
					}
					this.CreateGesture2Finger(EasyTouch.EvtType.On_Twist, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, num, 0f, this.twoFinger.fingerDistance);
				}
				this.twoFinger.lastTwistAngle = ((num == 0f) ? this.twoFinger.lastTwistAngle : num);
			}
		}

		// Token: 0x0601AE3C RID: 110140 RVA: 0x00846DC8 File Offset: 0x008451C8
		private void CreateStateEnd2Fingers(EasyTouch.GestureType gesture, Vector2 startPosition, Vector2 position, Vector2 deltaPosition, float time, bool realEnd, float fingerDistance, float twist = 0f, float pinch = 0f)
		{
			switch (gesture)
			{
			case EasyTouch.GestureType.LongTap:
				this.CreateGesture2Finger(EasyTouch.EvtType.On_LongTapEnd2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, fingerDistance);
				goto IL_1D2;
			case EasyTouch.GestureType.Pinch:
				this.CreateGesture2Finger(EasyTouch.EvtType.On_PinchEnd, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, this.twoFinger.lastPinch, fingerDistance);
				goto IL_1D2;
			case EasyTouch.GestureType.Twist:
				this.CreateGesture2Finger(EasyTouch.EvtType.On_TwistEnd, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, this.twoFinger.lastTwistAngle, 0f, fingerDistance);
				goto IL_1D2;
			default:
				if (gesture != EasyTouch.GestureType.Tap)
				{
					goto IL_1D2;
				}
				break;
			case EasyTouch.GestureType.Acquisition:
				break;
			}
			if (this.doubleTapDetection == EasyTouch.DoubleTapDetection.BySystem)
			{
				if (this.fingers[this.twoFinger.finger0].tapCount < 2 && this.fingers[this.twoFinger.finger1].tapCount < 2)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_SimpleTap2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, fingerDistance);
				}
				else
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_DoubleTap2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, fingerDistance);
				}
				this.twoFinger.currentGesture = EasyTouch.GestureType.None;
				this.twoFinger.pickedObject = null;
				this.twoFinger.swipeStart = false;
				this.twoFinger.dragStart = false;
				this.singleDoubleTap[99].Stop();
				base.StopCoroutine("SingleOrDouble2Fingers");
			}
			else if (!this.singleDoubleTap[99].inWait)
			{
				base.StartCoroutine("SingleOrDouble2Fingers");
			}
			else
			{
				this.singleDoubleTap[99].count++;
			}
			IL_1D2:
			if (realEnd)
			{
				if (this.twoFinger.dragStart)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_DragEnd2Fingers, startPosition, position, deltaPosition, time, this.GetSwipe(startPosition, position), (position - startPosition).magnitude, position - startPosition, 0f, 0f, fingerDistance);
				}
				if (this.twoFinger.swipeStart)
				{
					this.CreateGesture2Finger(EasyTouch.EvtType.On_SwipeEnd2Fingers, startPosition, position, deltaPosition, time, this.GetSwipe(startPosition, position), (position - startPosition).magnitude, position - startPosition, 0f, 0f, fingerDistance);
				}
				this.CreateGesture2Finger(EasyTouch.EvtType.On_TouchUp2Fingers, startPosition, position, deltaPosition, time, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, fingerDistance);
			}
		}

		// Token: 0x0601AE3D RID: 110141 RVA: 0x00847064 File Offset: 0x00845464
		private IEnumerator SingleOrDouble2Fingers()
		{
			this.singleDoubleTap[99].inWait = true;
			yield return new WaitForSeconds(this.doubleTapTime);
			if (this.singleDoubleTap[99].count < 2)
			{
				this.CreateGesture2Finger(EasyTouch.EvtType.On_SimpleTap2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
			}
			else
			{
				this.CreateGesture2Finger(EasyTouch.EvtType.On_DoubleTap2Fingers, this.twoFinger.startPosition, this.twoFinger.position, this.twoFinger.deltaPosition, this.twoFinger.timeSinceStartAction, EasyTouch.SwipeDirection.None, 0f, Vector2.zero, 0f, 0f, this.twoFinger.fingerDistance);
			}
			this.twoFinger.currentGesture = EasyTouch.GestureType.None;
			this.twoFinger.pickedObject = null;
			this.twoFinger.swipeStart = false;
			this.twoFinger.dragStart = false;
			this.singleDoubleTap[99].Stop();
			base.StopCoroutine("SingleOrDouble2Fingers");
			yield break;
		}

		// Token: 0x0601AE3E RID: 110142 RVA: 0x00847080 File Offset: 0x00845480
		private void CreateGesture2Finger(EasyTouch.EvtType message, Vector2 startPosition, Vector2 position, Vector2 deltaPosition, float actionTime, EasyTouch.SwipeDirection swipe, float swipeLength, Vector2 swipeVector, float twist, float pinch, float twoDistance)
		{
			bool flag = true;
			Gesture gesture = new Gesture();
			gesture.isOverGui = false;
			if (this.enabledNGuiMode && message == EasyTouch.EvtType.On_TouchStart2Fingers)
			{
				gesture.isOverGui = (gesture.isOverGui || (this.IsTouchOverNGui(this.twoFinger.position, false) && this.IsTouchOverNGui(this.twoFinger.position, false)));
			}
			gesture.touchCount = 2;
			gesture.fingerIndex = -1;
			gesture.startPosition = startPosition;
			gesture.position = position;
			gesture.deltaPosition = deltaPosition;
			gesture.actionTime = actionTime;
			gesture.deltaTime = Time.deltaTime;
			gesture.swipe = swipe;
			gesture.swipeLength = swipeLength;
			gesture.swipeVector = swipeVector;
			gesture.deltaPinch = pinch;
			gesture.twistAngle = twist;
			gesture.twoFingerDistance = twoDistance;
			gesture.pickedObject = this.twoFinger.pickedObject;
			gesture.pickedCamera = this.twoFinger.pickedCamera;
			gesture.isGuiCamera = this.twoFinger.isGuiCamera;
			if (this.autoUpdatePickedObject && message != EasyTouch.EvtType.On_Drag && message != EasyTouch.EvtType.On_DragEnd && message != EasyTouch.EvtType.On_Twist && message != EasyTouch.EvtType.On_TwistEnd && message != EasyTouch.EvtType.On_Pinch && message != EasyTouch.EvtType.On_PinchEnd && message != EasyTouch.EvtType.On_PinchIn && message != EasyTouch.EvtType.On_PinchOut)
			{
				if (this.GetTwoFingerPickedObject())
				{
					gesture.pickedObject = this.pickedObject.pickedObj;
					gesture.pickedCamera = this.pickedObject.pickedCamera;
					gesture.isGuiCamera = this.pickedObject.isGUI;
				}
				else
				{
					this.twoFinger.ClearPickedObjectData();
				}
			}
			gesture.pickedUIElement = this.twoFinger.pickedUIElement;
			gesture.isOverGui = this.twoFinger.isOverGui;
			if (this.allowUIDetection && this.autoUpdatePickedUI && message != EasyTouch.EvtType.On_Drag && message != EasyTouch.EvtType.On_DragEnd && message != EasyTouch.EvtType.On_Twist && message != EasyTouch.EvtType.On_TwistEnd && message != EasyTouch.EvtType.On_Pinch && message != EasyTouch.EvtType.On_PinchEnd && message != EasyTouch.EvtType.On_PinchIn && message != EasyTouch.EvtType.On_PinchOut && message == EasyTouch.EvtType.On_SimpleTap2Fingers)
			{
				if (this.GetTwoFingerPickedUIElement())
				{
					gesture.pickedUIElement = this.pickedObject.pickedObj;
					gesture.isOverGui = true;
				}
				else
				{
					this.twoFinger.ClearPickedUIData();
				}
			}
			if (this.enableUIMode || (this.enabledNGuiMode && this.allowUIDetection))
			{
				flag = !gesture.isOverGui;
			}
			if (flag)
			{
				this.RaiseEvent(message, gesture);
			}
			else if (gesture.isOverGui)
			{
				if (message == EasyTouch.EvtType.On_TouchUp2Fingers)
				{
					this.RaiseEvent(EasyTouch.EvtType.On_UIElementTouchUp, gesture);
				}
				else
				{
					this.RaiseEvent(EasyTouch.EvtType.On_OverUIElement, gesture);
				}
			}
		}

		// Token: 0x0601AE3F RID: 110143 RVA: 0x00847340 File Offset: 0x00845740
		private int GetTwoFinger(int index)
		{
			int num = index + 1;
			bool flag = false;
			while (num < 10 && !flag)
			{
				if (this.fingers[num] != null && num >= index)
				{
					flag = true;
				}
				num++;
			}
			return num - 1;
		}

		// Token: 0x0601AE40 RID: 110144 RVA: 0x00847388 File Offset: 0x00845788
		private bool GetTwoFingerPickedObject()
		{
			bool result = false;
			if (this.twoFingerPickMethod == EasyTouch.TwoFingerPickMethod.Finger)
			{
				if (this.GetPickedGameObject(this.fingers[this.twoFinger.finger0], false))
				{
					GameObject pickedObj = this.pickedObject.pickedObj;
					if (this.GetPickedGameObject(this.fingers[this.twoFinger.finger1], false) && pickedObj == this.pickedObject.pickedObj)
					{
						result = true;
					}
				}
			}
			else if (this.GetPickedGameObject(this.fingers[this.twoFinger.finger0], true))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0601AE41 RID: 110145 RVA: 0x00847428 File Offset: 0x00845828
		private bool GetTwoFingerPickedUIElement()
		{
			bool result = false;
			if (this.fingers[this.twoFinger.finger0] == null)
			{
				return false;
			}
			if (this.twoFingerPickMethod == EasyTouch.TwoFingerPickMethod.Finger)
			{
				if (this.IsScreenPositionOverUI(this.fingers[this.twoFinger.finger0].position))
				{
					GameObject firstUIElementFromCache = this.GetFirstUIElementFromCache();
					if (this.IsScreenPositionOverUI(this.fingers[this.twoFinger.finger1].position))
					{
						GameObject firstUIElementFromCache2 = this.GetFirstUIElementFromCache();
						if (firstUIElementFromCache2 == firstUIElementFromCache || firstUIElementFromCache2.transform.IsChildOf(firstUIElementFromCache.transform) || firstUIElementFromCache.transform.IsChildOf(firstUIElementFromCache2.transform))
						{
							this.pickedObject.pickedObj = firstUIElementFromCache;
							this.pickedObject.isGUI = true;
							result = true;
						}
					}
				}
			}
			else if (this.IsScreenPositionOverUI(this.twoFinger.position))
			{
				this.pickedObject.pickedObj = this.GetFirstUIElementFromCache();
				this.pickedObject.isGUI = true;
				result = true;
			}
			return result;
		}

		// Token: 0x0601AE42 RID: 110146 RVA: 0x0084753C File Offset: 0x0084593C
		private void RaiseEvent(EasyTouch.EvtType evnt, Gesture gesture)
		{
			gesture.type = evnt;
			switch (evnt)
			{
			case EasyTouch.EvtType.On_TouchStart:
				if (EasyTouch.On_TouchStart != null)
				{
					EasyTouch.On_TouchStart(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchDown:
				if (EasyTouch.On_TouchDown != null)
				{
					EasyTouch.On_TouchDown(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchUp:
				if (EasyTouch.On_TouchUp != null)
				{
					EasyTouch.On_TouchUp(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SimpleTap:
				if (EasyTouch.On_SimpleTap != null)
				{
					EasyTouch.On_SimpleTap(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DoubleTap:
				if (EasyTouch.On_DoubleTap != null)
				{
					EasyTouch.On_DoubleTap(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTapStart:
				if (EasyTouch.On_LongTapStart != null)
				{
					EasyTouch.On_LongTapStart(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTap:
				if (EasyTouch.On_LongTap != null)
				{
					EasyTouch.On_LongTap(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTapEnd:
				if (EasyTouch.On_LongTapEnd != null)
				{
					EasyTouch.On_LongTapEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DragStart:
				if (EasyTouch.On_DragStart != null)
				{
					EasyTouch.On_DragStart(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Drag:
				if (EasyTouch.On_Drag != null)
				{
					EasyTouch.On_Drag(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DragEnd:
				if (EasyTouch.On_DragEnd != null)
				{
					EasyTouch.On_DragEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SwipeStart:
				if (EasyTouch.On_SwipeStart != null)
				{
					EasyTouch.On_SwipeStart(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Swipe:
				if (EasyTouch.On_Swipe != null)
				{
					EasyTouch.On_Swipe(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SwipeEnd:
				if (EasyTouch.On_SwipeEnd != null)
				{
					EasyTouch.On_SwipeEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchStart2Fingers:
				if (EasyTouch.On_TouchStart2Fingers != null)
				{
					EasyTouch.On_TouchStart2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchDown2Fingers:
				if (EasyTouch.On_TouchDown2Fingers != null)
				{
					EasyTouch.On_TouchDown2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TouchUp2Fingers:
				if (EasyTouch.On_TouchUp2Fingers != null)
				{
					EasyTouch.On_TouchUp2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SimpleTap2Fingers:
				if (EasyTouch.On_SimpleTap2Fingers != null)
				{
					EasyTouch.On_SimpleTap2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DoubleTap2Fingers:
				if (EasyTouch.On_DoubleTap2Fingers != null)
				{
					EasyTouch.On_DoubleTap2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTapStart2Fingers:
				if (EasyTouch.On_LongTapStart2Fingers != null)
				{
					EasyTouch.On_LongTapStart2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTap2Fingers:
				if (EasyTouch.On_LongTap2Fingers != null)
				{
					EasyTouch.On_LongTap2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_LongTapEnd2Fingers:
				if (EasyTouch.On_LongTapEnd2Fingers != null)
				{
					EasyTouch.On_LongTapEnd2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Twist:
				if (EasyTouch.On_Twist != null)
				{
					EasyTouch.On_Twist(gesture);
				}
				break;
			case EasyTouch.EvtType.On_TwistEnd:
				if (EasyTouch.On_TwistEnd != null)
				{
					EasyTouch.On_TwistEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Pinch:
				if (EasyTouch.On_Pinch != null)
				{
					EasyTouch.On_Pinch(gesture);
				}
				break;
			case EasyTouch.EvtType.On_PinchIn:
				if (EasyTouch.On_PinchIn != null)
				{
					EasyTouch.On_PinchIn(gesture);
				}
				break;
			case EasyTouch.EvtType.On_PinchOut:
				if (EasyTouch.On_PinchOut != null)
				{
					EasyTouch.On_PinchOut(gesture);
				}
				break;
			case EasyTouch.EvtType.On_PinchEnd:
				if (EasyTouch.On_PinchEnd != null)
				{
					EasyTouch.On_PinchEnd(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DragStart2Fingers:
				if (EasyTouch.On_DragStart2Fingers != null)
				{
					EasyTouch.On_DragStart2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Drag2Fingers:
				if (EasyTouch.On_Drag2Fingers != null)
				{
					EasyTouch.On_Drag2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_DragEnd2Fingers:
				if (EasyTouch.On_DragEnd2Fingers != null)
				{
					EasyTouch.On_DragEnd2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SwipeStart2Fingers:
				if (EasyTouch.On_SwipeStart2Fingers != null)
				{
					EasyTouch.On_SwipeStart2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Swipe2Fingers:
				if (EasyTouch.On_Swipe2Fingers != null)
				{
					EasyTouch.On_Swipe2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_SwipeEnd2Fingers:
				if (EasyTouch.On_SwipeEnd2Fingers != null)
				{
					EasyTouch.On_SwipeEnd2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Cancel:
				if (EasyTouch.On_Cancel != null)
				{
					EasyTouch.On_Cancel(gesture);
				}
				break;
			case EasyTouch.EvtType.On_Cancel2Fingers:
				if (EasyTouch.On_Cancel2Fingers != null)
				{
					EasyTouch.On_Cancel2Fingers(gesture);
				}
				break;
			case EasyTouch.EvtType.On_OverUIElement:
				if (EasyTouch.On_OverUIElement != null)
				{
					EasyTouch.On_OverUIElement(gesture);
				}
				break;
			case EasyTouch.EvtType.On_UIElementTouchUp:
				if (EasyTouch.On_UIElementTouchUp != null)
				{
					EasyTouch.On_UIElementTouchUp(gesture);
				}
				break;
			}
			int num = this._currentGestures.FindIndex((Gesture obj) => obj.type == gesture.type && obj.fingerIndex == gesture.fingerIndex);
			if (num > -1)
			{
				this._currentGestures[num].touchCount = gesture.touchCount;
				this._currentGestures[num].position = gesture.position;
				this._currentGestures[num].actionTime = gesture.actionTime;
				this._currentGestures[num].pickedCamera = gesture.pickedCamera;
				this._currentGestures[num].pickedObject = gesture.pickedObject;
				this._currentGestures[num].pickedUIElement = gesture.pickedUIElement;
				this._currentGestures[num].isOverGui = gesture.isOverGui;
				this._currentGestures[num].isGuiCamera = gesture.isGuiCamera;
				this._currentGestures[num].deltaPinch += gesture.deltaPinch;
				this._currentGestures[num].deltaPosition += gesture.deltaPosition;
				this._currentGestures[num].deltaTime += gesture.deltaTime;
				this._currentGestures[num].twistAngle += gesture.twistAngle;
			}
			if (num == -1)
			{
				this._currentGestures.Add((Gesture)gesture.Clone());
				if (this._currentGestures.Count > 0)
				{
					this._currentGesture = this._currentGestures[0];
				}
			}
		}

		// Token: 0x0601AE43 RID: 110147 RVA: 0x00847C7C File Offset: 0x0084607C
		private bool GetPickedGameObject(Finger finger, bool isTowFinger = false)
		{
			if (finger == null && !isTowFinger)
			{
				return false;
			}
			this.pickedObject.isGUI = false;
			this.pickedObject.pickedObj = null;
			this.pickedObject.pickedCamera = null;
			if (this.touchCameras.Count > 0)
			{
				for (int i = 0; i < this.touchCameras.Count; i++)
				{
					if (this.touchCameras[i].camera != null && this.touchCameras[i].camera.enabled)
					{
						Vector2 position = Vector2.zero;
						if (!isTowFinger)
						{
							position = finger.position;
						}
						else
						{
							position = this.twoFinger.position;
						}
						if (this.GetGameObjectAt(position, this.touchCameras[i].camera, this.touchCameras[i].guiCamera))
						{
							return true;
						}
					}
				}
			}
			else
			{
				Debug.LogWarning("No camera is assigned to EasyTouch");
			}
			return false;
		}

		// Token: 0x0601AE44 RID: 110148 RVA: 0x00847D84 File Offset: 0x00846184
		private bool GetGameObjectAt(Vector2 position, Camera cam, bool isGuiCam)
		{
			Ray ray = cam.ScreenPointToRay(position);
			if (this.enable2D)
			{
				LayerMask layerMask = this.pickableLayers2D;
				RaycastHit2D[] array = new RaycastHit2D[1];
				if (Physics2D.GetRayIntersectionNonAlloc(ray, array, float.PositiveInfinity, layerMask) > 0)
				{
					this.pickedObject.pickedCamera = cam;
					this.pickedObject.isGUI = isGuiCam;
					this.pickedObject.pickedObj = array[0].collider.gameObject;
					return true;
				}
			}
			LayerMask layerMask2 = this.pickableLayers3D;
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, ref raycastHit, 3.4028235E+38f, layerMask2))
			{
				this.pickedObject.pickedCamera = cam;
				this.pickedObject.isGUI = isGuiCam;
				this.pickedObject.pickedObj = raycastHit.collider.gameObject;
				return true;
			}
			return false;
		}

		// Token: 0x0601AE45 RID: 110149 RVA: 0x00847E58 File Offset: 0x00846258
		private EasyTouch.SwipeDirection GetSwipe(Vector2 start, Vector2 end)
		{
			Vector2 normalized = (end - start).normalized;
			if (Vector2.Dot(normalized, Vector2.up) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.Up;
			}
			if (Vector2.Dot(normalized, -Vector2.up) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.Down;
			}
			if (Vector2.Dot(normalized, Vector2.right) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.Right;
			}
			if (Vector2.Dot(normalized, -Vector2.right) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.Left;
			}
			Vector2 vector = normalized;
			Vector2 vector2;
			vector2..ctor(0.5f, 0.5f);
			if (Vector2.Dot(vector, vector2.normalized) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.UpRight;
			}
			Vector2 vector3 = normalized;
			Vector2 vector4;
			vector4..ctor(0.5f, -0.5f);
			if (Vector2.Dot(vector3, vector4.normalized) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.DownRight;
			}
			Vector2 vector5 = normalized;
			Vector2 vector6;
			vector6..ctor(-0.5f, 0.5f);
			if (Vector2.Dot(vector5, vector6.normalized) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.UpLeft;
			}
			Vector2 vector7 = normalized;
			Vector2 vector8;
			vector8..ctor(-0.5f, -0.5f);
			if (Vector2.Dot(vector7, vector8.normalized) >= this.swipeTolerance)
			{
				return EasyTouch.SwipeDirection.DownLeft;
			}
			return EasyTouch.SwipeDirection.Other;
		}

		// Token: 0x0601AE46 RID: 110150 RVA: 0x00847F90 File Offset: 0x00846390
		private bool FingerInTolerance(Finger finger)
		{
			return (finger.position - finger.startPosition).sqrMagnitude <= this.StationaryTolerance * this.StationaryTolerance;
		}

		// Token: 0x0601AE47 RID: 110151 RVA: 0x00847FCC File Offset: 0x008463CC
		private bool IsTouchOverNGui(Vector2 position, bool isTwoFingers = false)
		{
			bool flag = false;
			if (this.enabledNGuiMode)
			{
				LayerMask layerMask = this.nGUILayers;
				int num = 0;
				while (!flag && num < this.nGUICameras.Count)
				{
					Vector2 vector = Vector2.zero;
					if (!isTwoFingers)
					{
						vector = position;
					}
					else
					{
						vector = this.twoFinger.position;
					}
					Ray ray = this.nGUICameras[num].ScreenPointToRay(vector);
					RaycastHit raycastHit;
					flag = Physics.Raycast(ray, ref raycastHit, float.MaxValue, layerMask);
					num++;
				}
			}
			return flag;
		}

		// Token: 0x0601AE48 RID: 110152 RVA: 0x00848064 File Offset: 0x00846464
		private Finger GetFinger(int finderId)
		{
			int num = 0;
			Finger finger = null;
			while (num < 10 && finger == null)
			{
				if (this.fingers[num] != null && this.fingers[num].fingerIndex == finderId)
				{
					finger = this.fingers[num];
				}
				num++;
			}
			return finger;
		}

		// Token: 0x0601AE49 RID: 110153 RVA: 0x008480B8 File Offset: 0x008464B8
		private bool IsScreenPositionOverUI(Vector2 position)
		{
			this.uiEventSystem = EventSystem.current;
			if (this.uiEventSystem != null)
			{
				this.uiPointerEventData = new PointerEventData(this.uiEventSystem);
				this.uiPointerEventData.position = position;
				this.uiEventSystem.RaycastAll(this.uiPointerEventData, this.uiRaycastResultCache);
				return this.uiRaycastResultCache.Count > 0;
			}
			return false;
		}

		// Token: 0x0601AE4A RID: 110154 RVA: 0x0084812C File Offset: 0x0084652C
		private GameObject GetFirstUIElementFromCache()
		{
			if (this.uiRaycastResultCache.Count > 0)
			{
				return this.uiRaycastResultCache[0].gameObject;
			}
			return null;
		}

		// Token: 0x0601AE4B RID: 110155 RVA: 0x00848160 File Offset: 0x00846560
		private GameObject GetFirstUIElement(Vector2 position)
		{
			if (this.IsScreenPositionOverUI(position))
			{
				return this.GetFirstUIElementFromCache();
			}
			return null;
		}

		// Token: 0x0601AE4C RID: 110156 RVA: 0x00848178 File Offset: 0x00846578
		public static bool IsFingerOverUIElement(int fingerIndex)
		{
			if (EasyTouch.instance != null)
			{
				Finger finger = EasyTouch.instance.GetFinger(fingerIndex);
				return finger != null && EasyTouch.instance.IsScreenPositionOverUI(finger.position);
			}
			return false;
		}

		// Token: 0x0601AE4D RID: 110157 RVA: 0x008481BC File Offset: 0x008465BC
		public static GameObject GetCurrentPickedUIElement(int fingerIndex, bool isTwoFinger)
		{
			if (!(EasyTouch.instance != null))
			{
				return null;
			}
			Finger finger = EasyTouch.instance.GetFinger(fingerIndex);
			if (finger != null || isTwoFinger)
			{
				Vector2 position = Vector2.zero;
				if (!isTwoFinger)
				{
					position = finger.position;
				}
				else
				{
					position = EasyTouch.instance.twoFinger.position;
				}
				return EasyTouch.instance.GetFirstUIElement(position);
			}
			return null;
		}

		// Token: 0x0601AE4E RID: 110158 RVA: 0x00848228 File Offset: 0x00846628
		public static GameObject GetCurrentPickedObject(int fingerIndex, bool isTwoFinger)
		{
			if (!(EasyTouch.instance != null))
			{
				return null;
			}
			Finger finger = EasyTouch.instance.GetFinger(fingerIndex);
			if ((finger != null || isTwoFinger) && EasyTouch.instance.GetPickedGameObject(finger, isTwoFinger))
			{
				return EasyTouch.instance.pickedObject.pickedObj;
			}
			return null;
		}

		// Token: 0x0601AE4F RID: 110159 RVA: 0x00848284 File Offset: 0x00846684
		public static GameObject GetGameObjectAt(Vector2 position, bool isTwoFinger = false)
		{
			if (EasyTouch.instance != null)
			{
				if (isTwoFinger)
				{
					position = EasyTouch.instance.twoFinger.position;
				}
				if (EasyTouch.instance.touchCameras.Count > 0)
				{
					int i = 0;
					while (i < EasyTouch.instance.touchCameras.Count)
					{
						if (EasyTouch.instance.touchCameras[i].camera != null && EasyTouch.instance.touchCameras[i].camera.enabled)
						{
							if (EasyTouch.instance.GetGameObjectAt(position, EasyTouch.instance.touchCameras[i].camera, EasyTouch.instance.touchCameras[i].guiCamera))
							{
								return EasyTouch.instance.pickedObject.pickedObj;
							}
							return null;
						}
						else
						{
							i++;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0601AE50 RID: 110160 RVA: 0x00848379 File Offset: 0x00846779
		public static int GetTouchCount()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.input.TouchCount();
			}
			return 0;
		}

		// Token: 0x0601AE51 RID: 110161 RVA: 0x0084839B File Offset: 0x0084679B
		public static void ResetTouch(int fingerIndex)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.GetFinger(fingerIndex).gesture = EasyTouch.GestureType.None;
			}
		}

		// Token: 0x0601AE52 RID: 110162 RVA: 0x008483BD File Offset: 0x008467BD
		public static void SetEnabled(bool enable)
		{
			EasyTouch.instance.enable = enable;
			if (enable)
			{
				EasyTouch.instance.ResetTouches();
			}
		}

		// Token: 0x0601AE53 RID: 110163 RVA: 0x008483DA File Offset: 0x008467DA
		public static bool GetEnabled()
		{
			return EasyTouch.instance && EasyTouch.instance.enable;
		}

		// Token: 0x0601AE54 RID: 110164 RVA: 0x008483F7 File Offset: 0x008467F7
		public static void SetEnableUIDetection(bool enable)
		{
			if (EasyTouch.instance != null)
			{
				EasyTouch.instance.allowUIDetection = enable;
			}
		}

		// Token: 0x0601AE55 RID: 110165 RVA: 0x00848414 File Offset: 0x00846814
		public static bool GetEnableUIDetection()
		{
			return EasyTouch.instance && EasyTouch.instance.allowUIDetection;
		}

		// Token: 0x0601AE56 RID: 110166 RVA: 0x00848431 File Offset: 0x00846831
		public static void SetUICompatibily(bool value)
		{
			if (EasyTouch.instance != null)
			{
				EasyTouch.instance.enableUIMode = value;
			}
		}

		// Token: 0x0601AE57 RID: 110167 RVA: 0x0084844E File Offset: 0x0084684E
		public static bool GetUIComptability()
		{
			return EasyTouch.instance != null && EasyTouch.instance.enableUIMode;
		}

		// Token: 0x0601AE58 RID: 110168 RVA: 0x0084846C File Offset: 0x0084686C
		public static void SetAutoUpdateUI(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.autoUpdatePickedUI = value;
			}
		}

		// Token: 0x0601AE59 RID: 110169 RVA: 0x00848488 File Offset: 0x00846888
		public static bool GetAutoUpdateUI()
		{
			return EasyTouch.instance && EasyTouch.instance.autoUpdatePickedUI;
		}

		// Token: 0x0601AE5A RID: 110170 RVA: 0x008484A5 File Offset: 0x008468A5
		public static void SetNGUICompatibility(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enabledNGuiMode = value;
			}
		}

		// Token: 0x0601AE5B RID: 110171 RVA: 0x008484C1 File Offset: 0x008468C1
		public static bool GetNGUICompatibility()
		{
			return EasyTouch.instance && EasyTouch.instance.enabledNGuiMode;
		}

		// Token: 0x0601AE5C RID: 110172 RVA: 0x008484DE File Offset: 0x008468DE
		public static void SetEnableAutoSelect(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.autoSelect = value;
			}
		}

		// Token: 0x0601AE5D RID: 110173 RVA: 0x008484FA File Offset: 0x008468FA
		public static bool GetEnableAutoSelect()
		{
			return EasyTouch.instance && EasyTouch.instance.autoSelect;
		}

		// Token: 0x0601AE5E RID: 110174 RVA: 0x00848517 File Offset: 0x00846917
		public static void SetAutoUpdatePickedObject(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.autoUpdatePickedObject = value;
			}
		}

		// Token: 0x0601AE5F RID: 110175 RVA: 0x00848533 File Offset: 0x00846933
		public static bool GetAutoUpdatePickedObject()
		{
			return EasyTouch.instance && EasyTouch.instance.autoUpdatePickedObject;
		}

		// Token: 0x0601AE60 RID: 110176 RVA: 0x00848550 File Offset: 0x00846950
		public static void Set3DPickableLayer(LayerMask mask)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.pickableLayers3D = mask;
			}
		}

		// Token: 0x0601AE61 RID: 110177 RVA: 0x0084856C File Offset: 0x0084696C
		public static LayerMask Get3DPickableLayer()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.pickableLayers3D;
			}
			return LayerMask.GetMask(new string[]
			{
				"Default"
			});
		}

		// Token: 0x0601AE62 RID: 110178 RVA: 0x008485A0 File Offset: 0x008469A0
		public static void AddCamera(Camera cam, bool guiCam = false)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.touchCameras.Add(new ECamera(cam, guiCam));
			}
		}

		// Token: 0x0601AE63 RID: 110179 RVA: 0x008485C8 File Offset: 0x008469C8
		public static void RemoveCamera(Camera cam)
		{
			if (EasyTouch.instance)
			{
				int num = EasyTouch.instance.touchCameras.FindIndex((ECamera c) => c.camera == cam);
				if (num > -1)
				{
					EasyTouch.instance.touchCameras[num] = null;
					EasyTouch.instance.touchCameras.RemoveAt(num);
				}
			}
		}

		// Token: 0x0601AE64 RID: 110180 RVA: 0x00848635 File Offset: 0x00846A35
		public static Camera GetCamera(int index = 0)
		{
			if (!EasyTouch.instance)
			{
				return null;
			}
			if (index < EasyTouch.instance.touchCameras.Count)
			{
				return EasyTouch.instance.touchCameras[index].camera;
			}
			return null;
		}

		// Token: 0x0601AE65 RID: 110181 RVA: 0x00848674 File Offset: 0x00846A74
		public static void SetEnable2DCollider(bool value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enable2D = value;
			}
		}

		// Token: 0x0601AE66 RID: 110182 RVA: 0x00848690 File Offset: 0x00846A90
		public static bool GetEnable2DCollider()
		{
			return EasyTouch.instance && EasyTouch.instance.enable2D;
		}

		// Token: 0x0601AE67 RID: 110183 RVA: 0x008486AD File Offset: 0x00846AAD
		public static void Set2DPickableLayer(LayerMask mask)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.pickableLayers2D = mask;
			}
		}

		// Token: 0x0601AE68 RID: 110184 RVA: 0x008486C9 File Offset: 0x00846AC9
		public static LayerMask Get2DPickableLayer()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.pickableLayers2D;
			}
			return LayerMask.GetMask(new string[]
			{
				"Default"
			});
		}

		// Token: 0x0601AE69 RID: 110185 RVA: 0x008486FD File Offset: 0x00846AFD
		public static void SetGesturePriority(EasyTouch.GesturePriority value)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.gesturePriority = value;
			}
		}

		// Token: 0x0601AE6A RID: 110186 RVA: 0x00848719 File Offset: 0x00846B19
		public static EasyTouch.GesturePriority GetGesturePriority()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.gesturePriority;
			}
			return EasyTouch.GesturePriority.Tap;
		}

		// Token: 0x0601AE6B RID: 110187 RVA: 0x00848736 File Offset: 0x00846B36
		public static void SetStationaryTolerance(float tolerance)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.StationaryTolerance = tolerance;
			}
		}

		// Token: 0x0601AE6C RID: 110188 RVA: 0x00848752 File Offset: 0x00846B52
		public static float GetStationaryTolerance()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.StationaryTolerance;
			}
			return -1f;
		}

		// Token: 0x0601AE6D RID: 110189 RVA: 0x00848773 File Offset: 0x00846B73
		public static void SetLongTapTime(float time)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.longTapTime = time;
			}
		}

		// Token: 0x0601AE6E RID: 110190 RVA: 0x0084878F File Offset: 0x00846B8F
		public static float GetlongTapTime()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.longTapTime;
			}
			return -1f;
		}

		// Token: 0x0601AE6F RID: 110191 RVA: 0x008487B0 File Offset: 0x00846BB0
		public static void SetDoubleTapTime(float time)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.doubleTapTime = time;
			}
		}

		// Token: 0x0601AE70 RID: 110192 RVA: 0x008487CC File Offset: 0x00846BCC
		public static float GetDoubleTapTime()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.doubleTapTime;
			}
			return -1f;
		}

		// Token: 0x0601AE71 RID: 110193 RVA: 0x008487ED File Offset: 0x00846BED
		public static void SetDoubleTapMethod(EasyTouch.DoubleTapDetection detection)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.doubleTapDetection = detection;
			}
		}

		// Token: 0x0601AE72 RID: 110194 RVA: 0x00848809 File Offset: 0x00846C09
		public static EasyTouch.DoubleTapDetection GetDoubleTapMethod()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.doubleTapDetection;
			}
			return EasyTouch.DoubleTapDetection.BySystem;
		}

		// Token: 0x0601AE73 RID: 110195 RVA: 0x00848826 File Offset: 0x00846C26
		public static void SetSwipeTolerance(float tolerance)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.swipeTolerance = tolerance;
			}
		}

		// Token: 0x0601AE74 RID: 110196 RVA: 0x00848842 File Offset: 0x00846C42
		public static float GetSwipeTolerance()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.swipeTolerance;
			}
			return -1f;
		}

		// Token: 0x0601AE75 RID: 110197 RVA: 0x00848863 File Offset: 0x00846C63
		public static void SetEnable2FingersGesture(bool enable)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enable2FingersGesture = enable;
			}
		}

		// Token: 0x0601AE76 RID: 110198 RVA: 0x0084887F File Offset: 0x00846C7F
		public static bool GetEnable2FingersGesture()
		{
			return EasyTouch.instance && EasyTouch.instance.enable2FingersGesture;
		}

		// Token: 0x0601AE77 RID: 110199 RVA: 0x0084889C File Offset: 0x00846C9C
		public static void SetTwoFingerPickMethod(EasyTouch.TwoFingerPickMethod pickMethod)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.twoFingerPickMethod = pickMethod;
			}
		}

		// Token: 0x0601AE78 RID: 110200 RVA: 0x008488B8 File Offset: 0x00846CB8
		public static EasyTouch.TwoFingerPickMethod GetTwoFingerPickMethod()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.twoFingerPickMethod;
			}
			return EasyTouch.TwoFingerPickMethod.Finger;
		}

		// Token: 0x0601AE79 RID: 110201 RVA: 0x008488D5 File Offset: 0x00846CD5
		public static void SetEnablePinch(bool enable)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enablePinch = enable;
			}
		}

		// Token: 0x0601AE7A RID: 110202 RVA: 0x008488F1 File Offset: 0x00846CF1
		public static bool GetEnablePinch()
		{
			return EasyTouch.instance && EasyTouch.instance.enablePinch;
		}

		// Token: 0x0601AE7B RID: 110203 RVA: 0x0084890E File Offset: 0x00846D0E
		public static void SetMinPinchLength(float length)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.minPinchLength = length;
			}
		}

		// Token: 0x0601AE7C RID: 110204 RVA: 0x0084892A File Offset: 0x00846D2A
		public static float GetMinPinchLength()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.minPinchLength;
			}
			return -1f;
		}

		// Token: 0x0601AE7D RID: 110205 RVA: 0x0084894B File Offset: 0x00846D4B
		public static void SetEnableTwist(bool enable)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.enableTwist = enable;
			}
		}

		// Token: 0x0601AE7E RID: 110206 RVA: 0x00848967 File Offset: 0x00846D67
		public static bool GetEnableTwist()
		{
			return EasyTouch.instance && EasyTouch.instance.enableTwist;
		}

		// Token: 0x0601AE7F RID: 110207 RVA: 0x00848984 File Offset: 0x00846D84
		public static void SetMinTwistAngle(float angle)
		{
			if (EasyTouch.instance)
			{
				EasyTouch.instance.minTwistAngle = angle;
			}
		}

		// Token: 0x0601AE80 RID: 110208 RVA: 0x008489A0 File Offset: 0x00846DA0
		public static float GetMinTwistAngle()
		{
			if (EasyTouch.instance)
			{
				return EasyTouch.instance.minTwistAngle;
			}
			return -1f;
		}

		// Token: 0x0601AE81 RID: 110209 RVA: 0x008489C1 File Offset: 0x00846DC1
		public static bool GetSecondeFingerSimulation()
		{
			return EasyTouch.instance != null && EasyTouch.instance.enableSimulation;
		}

		// Token: 0x0601AE82 RID: 110210 RVA: 0x008489DF File Offset: 0x00846DDF
		public static void SetSecondFingerSimulation(bool value)
		{
			if (EasyTouch.instance != null)
			{
				EasyTouch.instance.enableSimulation = value;
			}
		}

		// Token: 0x04012B83 RID: 76675
		private static EasyTouch _instance;

		// Token: 0x04012B84 RID: 76676
		private Gesture _currentGesture = new Gesture();

		// Token: 0x04012B85 RID: 76677
		private List<Gesture> _currentGestures = new List<Gesture>();

		// Token: 0x04012B86 RID: 76678
		public bool enable;

		// Token: 0x04012B87 RID: 76679
		public bool enableRemote;

		// Token: 0x04012B88 RID: 76680
		public EasyTouch.GesturePriority gesturePriority;

		// Token: 0x04012B89 RID: 76681
		public float StationaryTolerance;

		// Token: 0x04012B8A RID: 76682
		public float longTapTime;

		// Token: 0x04012B8B RID: 76683
		public float swipeTolerance;

		// Token: 0x04012B8C RID: 76684
		public float minPinchLength;

		// Token: 0x04012B8D RID: 76685
		public float minTwistAngle;

		// Token: 0x04012B8E RID: 76686
		public EasyTouch.DoubleTapDetection doubleTapDetection;

		// Token: 0x04012B8F RID: 76687
		public float doubleTapTime;

		// Token: 0x04012B90 RID: 76688
		public bool alwaysSendSwipe;

		// Token: 0x04012B91 RID: 76689
		public bool enable2FingersGesture;

		// Token: 0x04012B92 RID: 76690
		public bool enableTwist;

		// Token: 0x04012B93 RID: 76691
		public bool enablePinch;

		// Token: 0x04012B94 RID: 76692
		public bool enable2FingersSwipe;

		// Token: 0x04012B95 RID: 76693
		public EasyTouch.TwoFingerPickMethod twoFingerPickMethod;

		// Token: 0x04012B96 RID: 76694
		public List<ECamera> touchCameras;

		// Token: 0x04012B97 RID: 76695
		public bool autoSelect;

		// Token: 0x04012B98 RID: 76696
		public LayerMask pickableLayers3D;

		// Token: 0x04012B99 RID: 76697
		public bool enable2D;

		// Token: 0x04012B9A RID: 76698
		public LayerMask pickableLayers2D;

		// Token: 0x04012B9B RID: 76699
		public bool autoUpdatePickedObject;

		// Token: 0x04012B9C RID: 76700
		public bool allowUIDetection;

		// Token: 0x04012B9D RID: 76701
		public bool enableUIMode;

		// Token: 0x04012B9E RID: 76702
		public bool autoUpdatePickedUI;

		// Token: 0x04012B9F RID: 76703
		public bool enabledNGuiMode;

		// Token: 0x04012BA0 RID: 76704
		public LayerMask nGUILayers;

		// Token: 0x04012BA1 RID: 76705
		public List<Camera> nGUICameras;

		// Token: 0x04012BA2 RID: 76706
		public bool enableSimulation;

		// Token: 0x04012BA3 RID: 76707
		public KeyCode twistKey;

		// Token: 0x04012BA4 RID: 76708
		public KeyCode swipeKey;

		// Token: 0x04012BA5 RID: 76709
		public bool showGuiInspector;

		// Token: 0x04012BA6 RID: 76710
		public bool showSelectInspector;

		// Token: 0x04012BA7 RID: 76711
		public bool showGestureInspector;

		// Token: 0x04012BA8 RID: 76712
		public bool showTwoFingerInspector;

		// Token: 0x04012BA9 RID: 76713
		public bool showSecondFingerInspector;

		// Token: 0x04012BAA RID: 76714
		private EasyTouchInput input = new EasyTouchInput();

		// Token: 0x04012BAB RID: 76715
		private Finger[] fingers = new Finger[100];

		// Token: 0x04012BAC RID: 76716
		public Texture secondFingerTexture;

		// Token: 0x04012BAD RID: 76717
		private TwoFingerGesture twoFinger = new TwoFingerGesture();

		// Token: 0x04012BAE RID: 76718
		private int oldTouchCount;

		// Token: 0x04012BAF RID: 76719
		private EasyTouch.DoubleTap[] singleDoubleTap = new EasyTouch.DoubleTap[100];

		// Token: 0x04012BB0 RID: 76720
		private Finger[] tmpArray = new Finger[100];

		// Token: 0x04012BB1 RID: 76721
		private EasyTouch.PickedObject pickedObject = new EasyTouch.PickedObject();

		// Token: 0x04012BB2 RID: 76722
		private List<RaycastResult> uiRaycastResultCache = new List<RaycastResult>();

		// Token: 0x04012BB3 RID: 76723
		private PointerEventData uiPointerEventData;

		// Token: 0x04012BB4 RID: 76724
		private EventSystem uiEventSystem;

		// Token: 0x02004900 RID: 18688
		[Serializable]
		private class DoubleTap
		{
			// Token: 0x0601AE85 RID: 110213 RVA: 0x00848A16 File Offset: 0x00846E16
			public void Stop()
			{
				this.inDoubleTap = false;
				this.inWait = false;
				this.time = 0f;
				this.count = 0;
			}

			// Token: 0x04012BB6 RID: 76726
			public bool inDoubleTap;

			// Token: 0x04012BB7 RID: 76727
			public bool inWait;

			// Token: 0x04012BB8 RID: 76728
			public float time;

			// Token: 0x04012BB9 RID: 76729
			public int count;

			// Token: 0x04012BBA RID: 76730
			public Finger finger;
		}

		// Token: 0x02004901 RID: 18689
		private class PickedObject
		{
			// Token: 0x04012BBB RID: 76731
			public GameObject pickedObj;

			// Token: 0x04012BBC RID: 76732
			public Camera pickedCamera;

			// Token: 0x04012BBD RID: 76733
			public bool isGUI;
		}

		// Token: 0x02004902 RID: 18690
		// (Invoke) Token: 0x0601AE88 RID: 110216
		public delegate void TouchCancelHandler(Gesture gesture);

		// Token: 0x02004903 RID: 18691
		// (Invoke) Token: 0x0601AE8C RID: 110220
		public delegate void Cancel2FingersHandler(Gesture gesture);

		// Token: 0x02004904 RID: 18692
		// (Invoke) Token: 0x0601AE90 RID: 110224
		public delegate void TouchStartHandler(Gesture gesture);

		// Token: 0x02004905 RID: 18693
		// (Invoke) Token: 0x0601AE94 RID: 110228
		public delegate void TouchDownHandler(Gesture gesture);

		// Token: 0x02004906 RID: 18694
		// (Invoke) Token: 0x0601AE98 RID: 110232
		public delegate void TouchUpHandler(Gesture gesture);

		// Token: 0x02004907 RID: 18695
		// (Invoke) Token: 0x0601AE9C RID: 110236
		public delegate void SimpleTapHandler(Gesture gesture);

		// Token: 0x02004908 RID: 18696
		// (Invoke) Token: 0x0601AEA0 RID: 110240
		public delegate void DoubleTapHandler(Gesture gesture);

		// Token: 0x02004909 RID: 18697
		// (Invoke) Token: 0x0601AEA4 RID: 110244
		public delegate void LongTapStartHandler(Gesture gesture);

		// Token: 0x0200490A RID: 18698
		// (Invoke) Token: 0x0601AEA8 RID: 110248
		public delegate void LongTapHandler(Gesture gesture);

		// Token: 0x0200490B RID: 18699
		// (Invoke) Token: 0x0601AEAC RID: 110252
		public delegate void LongTapEndHandler(Gesture gesture);

		// Token: 0x0200490C RID: 18700
		// (Invoke) Token: 0x0601AEB0 RID: 110256
		public delegate void DragStartHandler(Gesture gesture);

		// Token: 0x0200490D RID: 18701
		// (Invoke) Token: 0x0601AEB4 RID: 110260
		public delegate void DragHandler(Gesture gesture);

		// Token: 0x0200490E RID: 18702
		// (Invoke) Token: 0x0601AEB8 RID: 110264
		public delegate void DragEndHandler(Gesture gesture);

		// Token: 0x0200490F RID: 18703
		// (Invoke) Token: 0x0601AEBC RID: 110268
		public delegate void SwipeStartHandler(Gesture gesture);

		// Token: 0x02004910 RID: 18704
		// (Invoke) Token: 0x0601AEC0 RID: 110272
		public delegate void SwipeHandler(Gesture gesture);

		// Token: 0x02004911 RID: 18705
		// (Invoke) Token: 0x0601AEC4 RID: 110276
		public delegate void SwipeEndHandler(Gesture gesture);

		// Token: 0x02004912 RID: 18706
		// (Invoke) Token: 0x0601AEC8 RID: 110280
		public delegate void TouchStart2FingersHandler(Gesture gesture);

		// Token: 0x02004913 RID: 18707
		// (Invoke) Token: 0x0601AECC RID: 110284
		public delegate void TouchDown2FingersHandler(Gesture gesture);

		// Token: 0x02004914 RID: 18708
		// (Invoke) Token: 0x0601AED0 RID: 110288
		public delegate void TouchUp2FingersHandler(Gesture gesture);

		// Token: 0x02004915 RID: 18709
		// (Invoke) Token: 0x0601AED4 RID: 110292
		public delegate void SimpleTap2FingersHandler(Gesture gesture);

		// Token: 0x02004916 RID: 18710
		// (Invoke) Token: 0x0601AED8 RID: 110296
		public delegate void DoubleTap2FingersHandler(Gesture gesture);

		// Token: 0x02004917 RID: 18711
		// (Invoke) Token: 0x0601AEDC RID: 110300
		public delegate void LongTapStart2FingersHandler(Gesture gesture);

		// Token: 0x02004918 RID: 18712
		// (Invoke) Token: 0x0601AEE0 RID: 110304
		public delegate void LongTap2FingersHandler(Gesture gesture);

		// Token: 0x02004919 RID: 18713
		// (Invoke) Token: 0x0601AEE4 RID: 110308
		public delegate void LongTapEnd2FingersHandler(Gesture gesture);

		// Token: 0x0200491A RID: 18714
		// (Invoke) Token: 0x0601AEE8 RID: 110312
		public delegate void TwistHandler(Gesture gesture);

		// Token: 0x0200491B RID: 18715
		// (Invoke) Token: 0x0601AEEC RID: 110316
		public delegate void TwistEndHandler(Gesture gesture);

		// Token: 0x0200491C RID: 18716
		// (Invoke) Token: 0x0601AEF0 RID: 110320
		public delegate void PinchInHandler(Gesture gesture);

		// Token: 0x0200491D RID: 18717
		// (Invoke) Token: 0x0601AEF4 RID: 110324
		public delegate void PinchOutHandler(Gesture gesture);

		// Token: 0x0200491E RID: 18718
		// (Invoke) Token: 0x0601AEF8 RID: 110328
		public delegate void PinchEndHandler(Gesture gesture);

		// Token: 0x0200491F RID: 18719
		// (Invoke) Token: 0x0601AEFC RID: 110332
		public delegate void PinchHandler(Gesture gesture);

		// Token: 0x02004920 RID: 18720
		// (Invoke) Token: 0x0601AF00 RID: 110336
		public delegate void DragStart2FingersHandler(Gesture gesture);

		// Token: 0x02004921 RID: 18721
		// (Invoke) Token: 0x0601AF04 RID: 110340
		public delegate void Drag2FingersHandler(Gesture gesture);

		// Token: 0x02004922 RID: 18722
		// (Invoke) Token: 0x0601AF08 RID: 110344
		public delegate void DragEnd2FingersHandler(Gesture gesture);

		// Token: 0x02004923 RID: 18723
		// (Invoke) Token: 0x0601AF0C RID: 110348
		public delegate void SwipeStart2FingersHandler(Gesture gesture);

		// Token: 0x02004924 RID: 18724
		// (Invoke) Token: 0x0601AF10 RID: 110352
		public delegate void Swipe2FingersHandler(Gesture gesture);

		// Token: 0x02004925 RID: 18725
		// (Invoke) Token: 0x0601AF14 RID: 110356
		public delegate void SwipeEnd2FingersHandler(Gesture gesture);

		// Token: 0x02004926 RID: 18726
		// (Invoke) Token: 0x0601AF18 RID: 110360
		public delegate void EasyTouchIsReadyHandler();

		// Token: 0x02004927 RID: 18727
		// (Invoke) Token: 0x0601AF1C RID: 110364
		public delegate void OverUIElementHandler(Gesture gesture);

		// Token: 0x02004928 RID: 18728
		// (Invoke) Token: 0x0601AF20 RID: 110368
		public delegate void UIElementTouchUpHandler(Gesture gesture);

		// Token: 0x02004929 RID: 18729
		public enum GesturePriority
		{
			// Token: 0x04012BBF RID: 76735
			Tap,
			// Token: 0x04012BC0 RID: 76736
			Slips
		}

		// Token: 0x0200492A RID: 18730
		public enum DoubleTapDetection
		{
			// Token: 0x04012BC2 RID: 76738
			BySystem,
			// Token: 0x04012BC3 RID: 76739
			ByTime
		}

		// Token: 0x0200492B RID: 18731
		public enum GestureType
		{
			// Token: 0x04012BC5 RID: 76741
			Tap,
			// Token: 0x04012BC6 RID: 76742
			Drag,
			// Token: 0x04012BC7 RID: 76743
			Swipe,
			// Token: 0x04012BC8 RID: 76744
			None,
			// Token: 0x04012BC9 RID: 76745
			LongTap,
			// Token: 0x04012BCA RID: 76746
			Pinch,
			// Token: 0x04012BCB RID: 76747
			Twist,
			// Token: 0x04012BCC RID: 76748
			Cancel,
			// Token: 0x04012BCD RID: 76749
			Acquisition
		}

		// Token: 0x0200492C RID: 18732
		public enum SwipeDirection
		{
			// Token: 0x04012BCF RID: 76751
			None,
			// Token: 0x04012BD0 RID: 76752
			Left,
			// Token: 0x04012BD1 RID: 76753
			Right,
			// Token: 0x04012BD2 RID: 76754
			Up,
			// Token: 0x04012BD3 RID: 76755
			Down,
			// Token: 0x04012BD4 RID: 76756
			UpLeft,
			// Token: 0x04012BD5 RID: 76757
			UpRight,
			// Token: 0x04012BD6 RID: 76758
			DownLeft,
			// Token: 0x04012BD7 RID: 76759
			DownRight,
			// Token: 0x04012BD8 RID: 76760
			Other,
			// Token: 0x04012BD9 RID: 76761
			All
		}

		// Token: 0x0200492D RID: 18733
		public enum TwoFingerPickMethod
		{
			// Token: 0x04012BDB RID: 76763
			Finger,
			// Token: 0x04012BDC RID: 76764
			Average
		}

		// Token: 0x0200492E RID: 18734
		public enum EvtType
		{
			// Token: 0x04012BDE RID: 76766
			None,
			// Token: 0x04012BDF RID: 76767
			On_TouchStart,
			// Token: 0x04012BE0 RID: 76768
			On_TouchDown,
			// Token: 0x04012BE1 RID: 76769
			On_TouchUp,
			// Token: 0x04012BE2 RID: 76770
			On_SimpleTap,
			// Token: 0x04012BE3 RID: 76771
			On_DoubleTap,
			// Token: 0x04012BE4 RID: 76772
			On_LongTapStart,
			// Token: 0x04012BE5 RID: 76773
			On_LongTap,
			// Token: 0x04012BE6 RID: 76774
			On_LongTapEnd,
			// Token: 0x04012BE7 RID: 76775
			On_DragStart,
			// Token: 0x04012BE8 RID: 76776
			On_Drag,
			// Token: 0x04012BE9 RID: 76777
			On_DragEnd,
			// Token: 0x04012BEA RID: 76778
			On_SwipeStart,
			// Token: 0x04012BEB RID: 76779
			On_Swipe,
			// Token: 0x04012BEC RID: 76780
			On_SwipeEnd,
			// Token: 0x04012BED RID: 76781
			On_TouchStart2Fingers,
			// Token: 0x04012BEE RID: 76782
			On_TouchDown2Fingers,
			// Token: 0x04012BEF RID: 76783
			On_TouchUp2Fingers,
			// Token: 0x04012BF0 RID: 76784
			On_SimpleTap2Fingers,
			// Token: 0x04012BF1 RID: 76785
			On_DoubleTap2Fingers,
			// Token: 0x04012BF2 RID: 76786
			On_LongTapStart2Fingers,
			// Token: 0x04012BF3 RID: 76787
			On_LongTap2Fingers,
			// Token: 0x04012BF4 RID: 76788
			On_LongTapEnd2Fingers,
			// Token: 0x04012BF5 RID: 76789
			On_Twist,
			// Token: 0x04012BF6 RID: 76790
			On_TwistEnd,
			// Token: 0x04012BF7 RID: 76791
			On_Pinch,
			// Token: 0x04012BF8 RID: 76792
			On_PinchIn,
			// Token: 0x04012BF9 RID: 76793
			On_PinchOut,
			// Token: 0x04012BFA RID: 76794
			On_PinchEnd,
			// Token: 0x04012BFB RID: 76795
			On_DragStart2Fingers,
			// Token: 0x04012BFC RID: 76796
			On_Drag2Fingers,
			// Token: 0x04012BFD RID: 76797
			On_DragEnd2Fingers,
			// Token: 0x04012BFE RID: 76798
			On_SwipeStart2Fingers,
			// Token: 0x04012BFF RID: 76799
			On_Swipe2Fingers,
			// Token: 0x04012C00 RID: 76800
			On_SwipeEnd2Fingers,
			// Token: 0x04012C01 RID: 76801
			On_EasyTouchIsReady,
			// Token: 0x04012C02 RID: 76802
			On_Cancel,
			// Token: 0x04012C03 RID: 76803
			On_Cancel2Fingers,
			// Token: 0x04012C04 RID: 76804
			On_OverUIElement,
			// Token: 0x04012C05 RID: 76805
			On_UIElementTouchUp
		}
	}
}
