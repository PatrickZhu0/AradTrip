using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ActivityLimitTime;
using AdsPush;
using GamePool;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020010FC RID: 4348
	public class ClientSystemManager : Singleton<ClientSystemManager>, IClientFrameManager, IClientSystemFrameStack
	{
		// Token: 0x170019AB RID: 6571
		// (get) Token: 0x0600A47F RID: 42111 RVA: 0x0021DB11 File Offset: 0x0021BF11
		// (set) Token: 0x0600A480 RID: 42112 RVA: 0x0021DB19 File Offset: 0x0021BF19
		public IClientSystem CurrentSystem { get; set; }

		// Token: 0x170019AC RID: 6572
		// (get) Token: 0x0600A481 RID: 42113 RVA: 0x0021DB22 File Offset: 0x0021BF22
		// (set) Token: 0x0600A482 RID: 42114 RVA: 0x0021DB2A File Offset: 0x0021BF2A
		public IClientSystem TargetSystem { get; set; }

		// Token: 0x170019AD RID: 6573
		// (get) Token: 0x0600A483 RID: 42115 RVA: 0x0021DB33 File Offset: 0x0021BF33
		// (set) Token: 0x0600A484 RID: 42116 RVA: 0x0021DB3B File Offset: 0x0021BF3B
		public float SwitchProgress { get; private set; }

		// Token: 0x170019AE RID: 6574
		// (get) Token: 0x0600A485 RID: 42117 RVA: 0x0021DB44 File Offset: 0x0021BF44
		// (set) Token: 0x0600A486 RID: 42118 RVA: 0x0021DB4C File Offset: 0x0021BF4C
		public string SwitchDescription { get; private set; }

		// Token: 0x170019AF RID: 6575
		// (get) Token: 0x0600A487 RID: 42119 RVA: 0x0021DB55 File Offset: 0x0021BF55
		// (set) Token: 0x0600A488 RID: 42120 RVA: 0x0021DB5D File Offset: 0x0021BF5D
		public bool bIsInPkWaitingRoom { get; set; }

		// Token: 0x170019B0 RID: 6576
		// (get) Token: 0x0600A489 RID: 42121 RVA: 0x0021DB66 File Offset: 0x0021BF66
		public int LoadingStep
		{
			get
			{
				return this.m_LoadingStep;
			}
		}

		// Token: 0x0600A48A RID: 42122 RVA: 0x0021DB6E File Offset: 0x0021BF6E
		public IClientSystem GetCurrentSystem()
		{
			if (this.TargetSystem != null)
			{
				return this.TargetSystem;
			}
			if (this.CurrentSystem != null)
			{
				return this.CurrentSystem;
			}
			return null;
		}

		// Token: 0x0600A48B RID: 42123 RVA: 0x0021DB98 File Offset: 0x0021BF98
		protected void _InitializeAudio()
		{
			MonoSingleton<AudioManager>.instance.Init();
			SoundConfig soundConfig = DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig;
			SoundConfig musicConfig = DataManager<SystemConfigManager>.GetInstance().SystemConfigData.MusicConfig;
			MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioStream, (float)soundConfig.Volume);
			MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioEffect, (float)musicConfig.Volume);
			MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioVoice, (float)musicConfig.Volume);
			Singleton<NpcVoiceCachedManager>.instance.SetVolume((float)musicConfig.Volume);
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioStream, soundConfig.Mute);
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioEffect, musicConfig.Mute);
			MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioVoice, musicConfig.Mute);
		}

		// Token: 0x0600A48C RID: 42124 RVA: 0x0021DC49 File Offset: 0x0021C049
		protected void _InitializeUI()
		{
			this._InitializeUIRoot();
			this._InitializeUICamera();
			this._Initialize2DUIRoot();
			this._Initialize3DUIRoot();
		}

		// Token: 0x0600A48D RID: 42125 RVA: 0x0021DC64 File Offset: 0x0021C064
		protected void _InitializeUIRoot()
		{
			this._layerRoot = Utility.FindGameObject("UIRoot", false);
			if (this._layerRoot != null)
			{
				Object.Destroy(this._layerRoot);
				this._layerRoot = null;
			}
			this._layerRoot = Singleton<AssetLoader>.instance.LoadResAsGameObject("Base/UI/Prefabs/Root/UIRoot", true, 0U);
			this._layerRoot.SetActive(true);
			this._layerRoot.name = "UIRoot";
			this._layerRoot.transform.SetAsFirstSibling();
			Object.DontDestroyOnLoad(this._layerRoot);
		}

		// Token: 0x170019B1 RID: 6577
		// (get) Token: 0x0600A48E RID: 42126 RVA: 0x0021DCF3 File Offset: 0x0021C0F3
		public Camera UICamera
		{
			get
			{
				return this._uiCamera;
			}
		}

		// Token: 0x0600A48F RID: 42127 RVA: 0x0021DCFC File Offset: 0x0021C0FC
		protected void _InitializeUICamera()
		{
			GameObject gameObject = Utility.FindGameObject(this._layerRoot, "UICamera", true);
			if (gameObject != null)
			{
				this._uiCamera = gameObject.GetComponent<Camera>();
			}
		}

		// Token: 0x170019B2 RID: 6578
		// (get) Token: 0x0600A490 RID: 42128 RVA: 0x0021DD33 File Offset: 0x0021C133
		protected GameObject[] LayerRoots
		{
			get
			{
				return this._layer2DRoots;
			}
		}

		// Token: 0x0600A491 RID: 42129 RVA: 0x0021DD3B File Offset: 0x0021C13B
		public GameObject GetLayer(FrameLayer layer)
		{
			if (this._layer2DRoots.Length == 8)
			{
				return this._layer2DRoots[(int)layer];
			}
			return null;
		}

		// Token: 0x170019B3 RID: 6579
		// (get) Token: 0x0600A492 RID: 42130 RVA: 0x0021DD55 File Offset: 0x0021C155
		public GameObject SceneUILayer
		{
			get
			{
				return this.m_objSceneUILayer;
			}
		}

		// Token: 0x170019B4 RID: 6580
		// (get) Token: 0x0600A493 RID: 42131 RVA: 0x0021DD5D File Offset: 0x0021C15D
		public GameObject BottomLayer
		{
			get
			{
				if (this._layer2DRoots.Length == 8)
				{
					return this._layer2DRoots[0];
				}
				Logger.LogError("ClientSystem._layerRoots not initialized!!");
				return null;
			}
		}

		// Token: 0x170019B5 RID: 6581
		// (get) Token: 0x0600A494 RID: 42132 RVA: 0x0021DD81 File Offset: 0x0021C181
		public GameObject MiddleLayer
		{
			get
			{
				if (this._layer2DRoots.Length == 8)
				{
					return this._layer2DRoots[2];
				}
				Logger.LogError("ClientSystem._layerRoots not initialized!!");
				return null;
			}
		}

		// Token: 0x170019B6 RID: 6582
		// (get) Token: 0x0600A495 RID: 42133 RVA: 0x0021DDA5 File Offset: 0x0021C1A5
		public GameObject HorseLampLayer
		{
			get
			{
				if (this._layer2DRoots.Length == 8)
				{
					return this._layer2DRoots[3];
				}
				Logger.LogError("ClientSystem._layerRoots not initialized!!");
				return null;
			}
		}

		// Token: 0x170019B7 RID: 6583
		// (get) Token: 0x0600A496 RID: 42134 RVA: 0x0021DDC9 File Offset: 0x0021C1C9
		public GameObject BelowMiddle
		{
			get
			{
				if (this._layer2DRoots.Length == 8)
				{
					return this._layer2DRoots[1];
				}
				Logger.LogError("ClientSystem._layerRoots not initialized!!");
				return null;
			}
		}

		// Token: 0x170019B8 RID: 6584
		// (get) Token: 0x0600A497 RID: 42135 RVA: 0x0021DDED File Offset: 0x0021C1ED
		public GameObject HighLayer
		{
			get
			{
				if (this._layer2DRoots.Length == 8)
				{
					return this._layer2DRoots[4];
				}
				Logger.LogError("ClientSystem._layerRoots not initialized!!");
				return null;
			}
		}

		// Token: 0x170019B9 RID: 6585
		// (get) Token: 0x0600A498 RID: 42136 RVA: 0x0021DE11 File Offset: 0x0021C211
		public GameObject TopLayer
		{
			get
			{
				if (this._layer2DRoots.Length == 8)
				{
					return this._layer2DRoots[5];
				}
				Logger.LogError("ClientSystem._layerRoots not initialized!!");
				return null;
			}
		}

		// Token: 0x170019BA RID: 6586
		// (get) Token: 0x0600A499 RID: 42137 RVA: 0x0021DE35 File Offset: 0x0021C235
		public GameObject TopMostLayer
		{
			get
			{
				if (this._layer2DRoots.Length == 8)
				{
					return this._layer2DRoots[6];
				}
				Logger.LogError("ClientSystem._layerRoots not initialized!!");
				return null;
			}
		}

		// Token: 0x170019BB RID: 6587
		// (get) Token: 0x0600A49A RID: 42138 RVA: 0x0021DE59 File Offset: 0x0021C259
		public GameObject TopMoreMostLayer
		{
			get
			{
				if (this._layer2DRoots.Length == 8)
				{
					return this._layer2DRoots[7];
				}
				Logger.LogError("ClientSystem._layerRoots not initialized!!");
				return null;
			}
		}

		// Token: 0x170019BC RID: 6588
		// (get) Token: 0x0600A49B RID: 42139 RVA: 0x0021DE7D File Offset: 0x0021C27D
		public Canvas UI2DCanvas
		{
			get
			{
				return this._canvas;
			}
		}

		// Token: 0x0600A49C RID: 42140 RVA: 0x0021DE88 File Offset: 0x0021C288
		protected void _Initialize2DUIRoot()
		{
			this._layer2DRoots = new GameObject[8];
			GameObject gameObject = Utility.FindGameObject(this._layerRoot, "UI2DRoot", true);
			this._canvas = gameObject.GetComponent<Canvas>();
			string[] array = new string[]
			{
				"Bottom",
				"BelowMiddle",
				"Middle",
				"HorseLamp",
				"High",
				"Top",
				"TopMost",
				"TopMoreMost"
			};
			for (int i = 0; i < 8; i++)
			{
				this._layer2DRoots[i] = Utility.FindGameObject(gameObject, array[i], true);
				if (this._layer2DRoots[i] == null)
				{
					GameObject gameObject2 = new GameObject
					{
						name = array[i]
					};
					RectTransform rectTransform = gameObject2.AddComponent<RectTransform>();
					rectTransform.anchorMax = Vector2.one;
					rectTransform.anchorMin = Vector2.zero;
					rectTransform.offsetMax = Vector2.zero;
					rectTransform.offsetMin = Vector2.zero;
					this._layer2DRoots[i] = gameObject2;
					Utility.AttachTo(gameObject2, gameObject, false);
				}
			}
			this.m_objSceneUILayer = Utility.FindGameObject(gameObject, "SceneUI", true);
		}

		// Token: 0x0600A49D RID: 42141 RVA: 0x0021DFAC File Offset: 0x0021C3AC
		protected void _Initialize3DUIRoot()
		{
			this._layer3DRoot = Utility.FindGameObject(this._layerRoot, "UI3DRoot", true);
		}

		// Token: 0x170019BD RID: 6589
		// (get) Token: 0x0600A49E RID: 42142 RVA: 0x0021DFC5 File Offset: 0x0021C3C5
		public GameObject Layer3DRoot
		{
			get
			{
				return this._layer3DRoot;
			}
		}

		// Token: 0x0600A49F RID: 42143 RVA: 0x0021DFD0 File Offset: 0x0021C3D0
		public void Clear3DUIRoot()
		{
			for (int i = 0; i < this._layer3DRoot.transform.childCount; i++)
			{
				GameObject gameObject = this._layer3DRoot.transform.GetChild(i).gameObject;
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
		}

		// Token: 0x0600A4A0 RID: 42144 RVA: 0x0021E028 File Offset: 0x0021C428
		private bool _checkIsValidType(Type type)
		{
			if (type == null)
			{
				Logger.LogError("type is nil");
				return false;
			}
			if (type.IsClass && type.GetInterface("GameClient.IClientFrame") != null)
			{
				return true;
			}
			Logger.LogErrorFormat("not valid type with name {0}", new object[]
			{
				type.Name
			});
			return false;
		}

		// Token: 0x0600A4A1 RID: 42145 RVA: 0x0021E080 File Offset: 0x0021C480
		private IClientFrame _getFrameByName(string name)
		{
			IClientFrame result = null;
			if (!this._frameDics.TryGetValue(name, out result))
			{
			}
			return result;
		}

		// Token: 0x0600A4A2 RID: 42146 RVA: 0x0021E0A3 File Offset: 0x0021C4A3
		private IClientFrame _getFrameByType(Type type)
		{
			if (!this._checkIsValidType(type))
			{
				return null;
			}
			return this._getFrameByName(type.Name);
		}

		// Token: 0x0600A4A3 RID: 42147 RVA: 0x0021E0C0 File Offset: 0x0021C4C0
		public IClientFrame OpenFrame(string luaFrameName)
		{
			GameObject gameObject = null;
			if (gameObject == null)
			{
				gameObject = this.LayerRoots[5];
			}
			IClientFrame clientFrame = null;
			if (!this._frameDics.TryGetValue(luaFrameName, out clientFrame))
			{
				clientFrame.SetManager(this);
				clientFrame.SetFrameName(luaFrameName);
				this._frameDics.Add(luaFrameName, clientFrame);
			}
			clientFrame.Open(gameObject, null, FrameLayer.Invalid);
			clientFrame.SetGlobal(false);
			return clientFrame;
		}

		// Token: 0x0600A4A4 RID: 42148 RVA: 0x0021E128 File Offset: 0x0021C528
		public IClientFrame OpenGlobalFrame<T>(FrameLayer layer, object userData = null) where T : class, IClientFrame
		{
			IClientFrame clientFrame = this.OpenFrame(typeof(T), layer, userData, string.Empty);
			clientFrame.SetGlobal(true);
			return clientFrame;
		}

		// Token: 0x0600A4A5 RID: 42149 RVA: 0x0021E155 File Offset: 0x0021C555
		public IClientFrame OpenFrame<T>(GameObject root, object userData = null, string name = "") where T : class, IClientFrame
		{
			return this.OpenFrame(typeof(T), root, userData, name, FrameLayer.Invalid);
		}

		// Token: 0x0600A4A6 RID: 42150 RVA: 0x0021E16B File Offset: 0x0021C56B
		public IClientFrame OpenFrame(GameObject root, Type type, object userData = null, string name = "")
		{
			return this.OpenFrame(type, root, userData, name, FrameLayer.Invalid);
		}

		// Token: 0x0600A4A7 RID: 42151 RVA: 0x0021E179 File Offset: 0x0021C579
		public IClientFrame OpenFrame<T>(FrameLayer layer = FrameLayer.Middle, object userData = null, string name = "") where T : class, IClientFrame
		{
			return this.OpenFrame(typeof(T), layer, userData, name);
		}

		// Token: 0x0600A4A8 RID: 42152 RVA: 0x0021E18E File Offset: 0x0021C58E
		public IClientFrame OpenFrame(Type type, FrameLayer layer = FrameLayer.Middle, object userData = null, string name = "")
		{
			return this.OpenFrame(type, this.LayerRoots[(int)layer], userData, name, layer);
		}

		// Token: 0x0600A4A9 RID: 42153 RVA: 0x0021E1A4 File Offset: 0x0021C5A4
		public IClientFrame OpenFrame(Type type, GameObject root, object userData = null, string name = "", FrameLayer layer = FrameLayer.Invalid)
		{
			if (!this._checkIsValidType(type))
			{
				return null;
			}
			if (this.LayerRoots == null)
			{
				Logger.LogErrorFormat("OpenFrame时LayerRoots == null,type = {0},name = {1}", new object[]
				{
					type,
					name
				});
				return null;
			}
			if (root == null)
			{
				root = this.LayerRoots[2];
			}
			if (root == null)
			{
				Logger.LogErrorFormat("root被LayerRoots赋值后依然为null,LayerRoots[(int)FrameLayer.Middle] = {0}", new object[]
				{
					this.LayerRoots[2]
				});
				return null;
			}
			string text = name;
			if (text == string.Empty)
			{
				text = type.Name;
			}
			if (text == "SmithShopFrame" && PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return null;
			}
			IClientFrame clientFrame;
			if (!this._frameDics.TryGetValue(text, out clientFrame))
			{
				clientFrame = (Activator.CreateInstance(type) as IClientFrame);
				clientFrame.SetManager(this);
				clientFrame.SetFrameName(text);
				this._frameDics.Add(text, clientFrame);
			}
			if (clientFrame == null)
			{
				Logger.LogErrorFormat("OpenFrame时frame为null的唯一情况就是从_frameDics取出来的值本身就是null,frameName = {0}", new object[]
				{
					text
				});
				return null;
			}
			clientFrame.Open(root, userData, layer);
			clientFrame.SetGlobal(false);
			if (!this._activeFrames.Contains(clientFrame))
			{
				this._activeFrames.Add(clientFrame);
				this._addMutexFrames(clientFrame);
			}
			UIEvent uiEvent = new UIEvent
			{
				EventID = EUIEventID.FrameOpen,
				Param1 = text,
				Param2 = type
			};
			GlobalEventSystem.GetInstance().SendUIEvent(uiEvent);
			return clientFrame;
		}

		// Token: 0x0600A4AA RID: 42154 RVA: 0x0021E328 File Offset: 0x0021C728
		private void _addMutexFrames(IClientFrame frame)
		{
			string groupTag = frame.GetGroupTag();
			if (groupTag.Length > 0)
			{
				if (!this._clientGroups.ContainsKey(groupTag))
				{
					this._clientGroups.Add(groupTag, new ClientSystemManager.ClientFrameGroup(groupTag));
				}
				List<string> list = this._clientGroups[groupTag].ClientFrames();
				if (!this._clientGroups[groupTag].IsGroupShow())
				{
					frame.Show(false, null);
				}
				else if (list.Count <= 0)
				{
					this._updateMutextFrames(groupTag, true);
				}
				list.Add(frame.GetFrameName());
			}
		}

		// Token: 0x0600A4AB RID: 42155 RVA: 0x0021E3C0 File Offset: 0x0021C7C0
		private void _removeMutexFrames(IClientFrame frame)
		{
			string groupTag = frame.GetGroupTag();
			if (groupTag.Length > 0)
			{
				if (this._clientGroups.ContainsKey(groupTag))
				{
					List<string> list = this._clientGroups[groupTag].ClientFrames();
					list.Remove(frame.GetFrameName());
					if (list.Count <= 0)
					{
						this._updateMutextFrames(groupTag, false);
						this._clientGroups.Remove(groupTag);
					}
				}
				else
				{
					Logger.LogErrorFormat("can't find the groupTag {0} with frame name {1} ", new object[]
					{
						groupTag,
						frame.GetFrameName()
					});
				}
			}
		}

		// Token: 0x0600A4AC RID: 42156 RVA: 0x0021E454 File Offset: 0x0021C854
		private void _showGroupFrame(ClientSystemManager.ClientFrameGroup group, bool isShow)
		{
			List<string> list = group.ClientFrames();
			for (int i = 0; i < list.Count; i++)
			{
				string name = list[i];
				IClientFrame clientFrame = this._getFrameByName(name);
				if (clientFrame.NeedMutex())
				{
					if (clientFrame != null)
					{
						clientFrame.Show(isShow, null);
					}
				}
			}
			if (group.GroupTag() == "system")
			{
				ClientSystem clientSystem = this.CurrentSystem as ClientSystem;
				if (clientSystem != null)
				{
					clientSystem.ShowMainFrame(isShow);
				}
			}
		}

		// Token: 0x0600A4AD RID: 42157 RVA: 0x0021E4E0 File Offset: 0x0021C8E0
		private void _updateMutextFrames(string tag, bool isShow)
		{
			foreach (KeyValuePair<string, ClientSystemManager.ClientFrameGroup> keyValuePair in this._clientGroups)
			{
				if (keyValuePair.Key != tag)
				{
					DictionaryView<string, ClientSystemManager.ClientFrameGroup>.Enumerator enumerator;
					KeyValuePair<string, ClientSystemManager.ClientFrameGroup> keyValuePair2 = enumerator.Current;
					ClientSystemManager.ClientFrameGroup value = keyValuePair2.Value;
					string hiddentGroup = value.GetHiddentGroup();
					if (isShow && hiddentGroup.Length <= 0)
					{
						value.SetHiddenGroup(tag);
						this._showGroupFrame(value, !isShow);
					}
					else if (!isShow && hiddentGroup == tag)
					{
						value.SetHiddenGroup(string.Empty);
						this._showGroupFrame(value, !isShow);
					}
				}
			}
		}

		// Token: 0x0600A4AE RID: 42158 RVA: 0x0021E58F File Offset: 0x0021C98F
		private void _clearMutextFrameHiddenTag()
		{
			this._clientGroups.Clear();
			this._clientGroups.Add("system", new ClientSystemManager.ClientFrameGroup("system"));
		}

		// Token: 0x0600A4AF RID: 42159 RVA: 0x0021E5B8 File Offset: 0x0021C9B8
		private ClientSystemManager.ClientFrameGroup _findClientGroupByFrameName(string clientframename)
		{
			foreach (KeyValuePair<string, ClientSystemManager.ClientFrameGroup> keyValuePair in this._clientGroups)
			{
				List<string> list = keyValuePair.Value.ClientFrames();
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] == clientframename)
					{
						DictionaryView<string, ClientSystemManager.ClientFrameGroup>.Enumerator enumerator;
						KeyValuePair<string, ClientSystemManager.ClientFrameGroup> keyValuePair2 = enumerator.Current;
						return keyValuePair2.Value;
					}
				}
			}
			return null;
		}

		// Token: 0x0600A4B0 RID: 42160 RVA: 0x0021E634 File Offset: 0x0021CA34
		private List<string> _gatherAllMutexFrame()
		{
			List<string> list = new List<string>();
			DictionaryView<string, ClientSystemManager.ClientFrameGroup>.Enumerator enumerator = this._clientGroups.GetEnumerator();
			while (enumerator.MoveNext())
			{
				List<string> list2 = list;
				KeyValuePair<string, ClientSystemManager.ClientFrameGroup> keyValuePair = enumerator.Current;
				list2.AddRange(keyValuePair.Value.ClientFrames());
			}
			return list;
		}

		// Token: 0x0600A4B1 RID: 42161 RVA: 0x0021E680 File Offset: 0x0021CA80
		private List<string> _forceShowGroup(ClientSystemManager.ClientFrameGroup group)
		{
			if (group == null || group.IsGroupShow())
			{
				return this._gatherAllMutexFrame();
			}
			string hiddentGroup = group.GetHiddentGroup();
			ClientSystemManager.ClientFrameGroup clientFrameGroup = this._clientGroups[hiddentGroup];
			Stack<string> stack = new Stack<string>();
			while (clientFrameGroup != null)
			{
				stack.Push(clientFrameGroup.GroupTag());
				if (!this._clientGroups.ContainsKey(clientFrameGroup.GetHiddentGroup()))
				{
					break;
				}
				clientFrameGroup = this._clientGroups[clientFrameGroup.GetHiddentGroup()];
			}
			while (stack.Count > 0)
			{
				string key = stack.Pop();
				if (this._clientGroups.ContainsKey(key))
				{
					List<string> list = this._clientGroups[key].ClientFrames();
					for (int i = 0; i < list.Count; i++)
					{
						IClientFrame clientFrame = this._getFrameByName(list[i]);
						if (clientFrame != null)
						{
							this._closeFrame(clientFrame, false);
						}
					}
				}
			}
			return this._gatherAllMutexFrame();
		}

		// Token: 0x0600A4B2 RID: 42162 RVA: 0x0021E788 File Offset: 0x0021CB88
		private void _forceClearFrameExcept(List<string> framenames)
		{
			List<IClientFrame> list = new List<IClientFrame>();
			string a = string.Empty;
			for (int i = 0; i < this._activeFrames.Count; i++)
			{
				a = this._activeFrames[i].GetFrameName();
				bool flag = true;
				for (int j = 0; j < framenames.Count; j++)
				{
					if (a == framenames[j])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(this._activeFrames[i]);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				this._closeFrame(list[k], false);
			}
			list.Clear();
		}

		// Token: 0x0600A4B3 RID: 42163 RVA: 0x0021E850 File Offset: 0x0021CC50
		public bool IsMainPrefabTop()
		{
			ClientSystemManager.ClientFrameGroup clientFrameGroup = this._clientGroups["system"];
			if (clientFrameGroup != null)
			{
				List<string> list = clientFrameGroup.ClientFrames();
				for (int i = 0; i < list.Count; i++)
				{
					string framename = list[i];
					IClientFrame clientFrame = this._activeFrames.Find((IClientFrame x) => x.GetFrameName() == framename);
					if (clientFrame == null || clientFrame.IsHidden())
					{
						return false;
					}
				}
				return this._activeFrames.Count <= list.Count;
			}
			return false;
		}

		// Token: 0x0600A4B4 RID: 42164 RVA: 0x0021E8F0 File Offset: 0x0021CCF0
		public void ForceClearFrame(string framename)
		{
			ClientSystemManager.ClientFrameGroup clientFrameGroup = this._findClientGroupByFrameName(framename);
			if (clientFrameGroup == null)
			{
				clientFrameGroup = this._clientGroups["system"];
			}
			List<string> list = this._forceShowGroup(clientFrameGroup);
			list.Add(framename);
			this._forceClearFrameExcept(list);
		}

		// Token: 0x0600A4B5 RID: 42165 RVA: 0x0021E932 File Offset: 0x0021CD32
		public void NotifyFrameIsOpen(IClientFrame frame)
		{
			if (frame == null)
			{
				Logger.LogError("[ClientFrameManager] 传入frame为空");
				return;
			}
			this.mFullScreenFrames.Add(frame);
			this.mFullScreenDirtyFlag = true;
		}

		// Token: 0x0600A4B6 RID: 42166 RVA: 0x0021E958 File Offset: 0x0021CD58
		public void NotifyFrameIsClose(IClientFrame frame)
		{
			if (frame == null)
			{
				Logger.LogError("[ClientFrameManager] 传入frame为空");
				return;
			}
			this.mFullScreenFrames.Remove(frame);
			this.mFullScreenDirtyFlag = true;
		}

		// Token: 0x0600A4B7 RID: 42167 RVA: 0x0021E980 File Offset: 0x0021CD80
		private void _updateFullScreen(float delta)
		{
			if (this.mFullScreenDirtyFlag)
			{
				bool mainCamera = this.mFullScreenFrames.Count <= 0;
				MonoSingleton<GameFrameWork>.instance.SetMainCamera(mainCamera);
				this._tryCloseNeedCloseFullScreenFrames();
				this.mFullScreenDirtyFlag = false;
			}
		}

		// Token: 0x0600A4B8 RID: 42168 RVA: 0x0021E9C4 File Offset: 0x0021CDC4
		private void _tryCloseNeedCloseFullScreenFrames()
		{
			this.mCacheFullScreenFramesToClose.Clear();
			for (int i = 0; i < this.mFullScreenFrames.Count - 1; i++)
			{
				if (this.mFullScreenFrames[i].IsFullScreenFrameNeedBeClose())
				{
					this.mCacheFullScreenFramesToClose.Add(this.mFullScreenFrames[i]);
				}
			}
			for (int j = 0; j < this.mCacheFullScreenFramesToClose.Count; j++)
			{
				this.CloseFrame<IClientFrame>(this.mCacheFullScreenFramesToClose[j], false);
			}
			this.mCacheFullScreenFramesToClose.Clear();
		}

		// Token: 0x0600A4B9 RID: 42169 RVA: 0x0021EA61 File Offset: 0x0021CE61
		private void _clearFullScreenStatus()
		{
			this.mFullScreenFrames.Clear();
			this.mCacheFullScreenFramesToClose.Clear();
			this.mFullScreenDirtyFlag = false;
			MonoSingleton<GameFrameWork>.instance.SetMainCamera(true);
		}

		// Token: 0x0600A4BA RID: 42170 RVA: 0x0021EA8B File Offset: 0x0021CE8B
		private void _closeFrame(IClientFrame frame, bool bImmediately = false)
		{
			if (frame == null || !frame.IsOpen())
			{
				return;
			}
			frame.Close(bImmediately);
		}

		// Token: 0x0600A4BB RID: 42171 RVA: 0x0021EAA6 File Offset: 0x0021CEA6
		public void OnFrameClose(IClientFrame frame, bool removeRef)
		{
			if (frame == null)
			{
				return;
			}
			this._activeFrames.Remove(frame);
			if (removeRef)
			{
				this._frameDics.Remove(frame.GetFrameName());
			}
			this._removeMutexFrames(frame);
		}

		// Token: 0x0600A4BC RID: 42172 RVA: 0x0021EADC File Offset: 0x0021CEDC
		public void CloseFrameByType(Type type, bool bImmediately = false)
		{
			IClientFrame frame = this._getFrameByType(type);
			this._closeFrame(frame, bImmediately);
		}

		// Token: 0x0600A4BD RID: 42173 RVA: 0x0021EAFC File Offset: 0x0021CEFC
		public void CloseFrame<T>(T frame = default(T), bool bImmediately = false) where T : class, IClientFrame
		{
			Type typeFromHandle = typeof(T);
			if (frame == null)
			{
				frame = (this._getFrameByType(typeFromHandle) as T);
				if (frame == null)
				{
					return;
				}
			}
			this._closeFrame(frame, bImmediately);
		}

		// Token: 0x0600A4BE RID: 42174 RVA: 0x0021EB4C File Offset: 0x0021CF4C
		public void CloseFrame(Type frameType, bool bImmediately = false)
		{
			IClientFrame clientFrame = this._getFrameByType(frameType);
			if (clientFrame != null)
			{
				this._closeFrame(clientFrame, bImmediately);
			}
		}

		// Token: 0x0600A4BF RID: 42175 RVA: 0x0021EB70 File Offset: 0x0021CF70
		public void CloseFrame(string FrameName)
		{
			IClientFrame frame = this._getFrameByName(FrameName);
			this._closeFrame(frame, false);
		}

		// Token: 0x0600A4C0 RID: 42176 RVA: 0x0021EB8D File Offset: 0x0021CF8D
		public IClientFrame GetFrame(Type type)
		{
			return this._getFrameByType(type);
		}

		// Token: 0x0600A4C1 RID: 42177 RVA: 0x0021EB96 File Offset: 0x0021CF96
		public IClientFrame GetFrame(string name)
		{
			return this._getFrameByName(name);
		}

		// Token: 0x0600A4C2 RID: 42178 RVA: 0x0021EBA0 File Offset: 0x0021CFA0
		public bool HasActiveFrame(string type)
		{
			for (int i = 0; i < this._activeFrames.Count; i++)
			{
				if (this._activeFrames[i] != null && this._activeFrames[i].GetType().Name == type)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A4C3 RID: 42179 RVA: 0x0021EC00 File Offset: 0x0021D000
		public bool IsFrameOpen(Type type)
		{
			IClientFrame clientFrame = this._getFrameByType(type);
			return clientFrame != null && clientFrame.IsOpen();
		}

		// Token: 0x0600A4C4 RID: 42180 RVA: 0x0021EC24 File Offset: 0x0021D024
		public bool IsFrameOpen<T>(T frame = default(T)) where T : class, IClientFrame
		{
			Type typeFromHandle = typeof(T);
			if (frame == null)
			{
				IClientFrame clientFrame = frame;
				if (!this._frameDics.TryGetValue(typeFromHandle.Name, out clientFrame))
				{
					return false;
				}
				frame = (clientFrame as T);
			}
			return frame.IsOpen();
		}

		// Token: 0x0600A4C5 RID: 42181 RVA: 0x0021EC84 File Offset: 0x0021D084
		public bool IsFrameOpen(string FrameName)
		{
			IClientFrame clientFrame;
			return this._frameDics.TryGetValue(FrameName, out clientFrame) && clientFrame.IsOpen();
		}

		// Token: 0x0600A4C6 RID: 42182 RVA: 0x0021ECAC File Offset: 0x0021D0AC
		public bool IsFrameHidden(Type type)
		{
			IClientFrame clientFrame = this._getFrameByType(type);
			return clientFrame == null || clientFrame.IsHidden();
		}

		// Token: 0x0600A4C7 RID: 42183 RVA: 0x0021ECD0 File Offset: 0x0021D0D0
		private void _closeAllActiveFrame(bool closeGlobal, bool removeRef)
		{
			List<IClientFrame> list = ListPool<IClientFrame>.Get();
			for (int i = 0; i < this._activeFrames.Count; i++)
			{
				ClientFrame clientFrame = this._activeFrames[i] as ClientFrame;
				if (closeGlobal || clientFrame == null || !clientFrame.IsGlobal())
				{
					list.Add(clientFrame);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				IClientFrame clientFrame2 = list[j];
				if (clientFrame2 != null)
				{
					clientFrame2.Close(true);
				}
			}
			ListPool<IClientFrame>.Release(list);
			this._clearMutextFrameHiddenTag();
			this._clearFullScreenStatus();
		}

		// Token: 0x0600A4C8 RID: 42184 RVA: 0x0021ED70 File Offset: 0x0021D170
		private void _clearAllGameObjects(bool closeGlobal)
		{
			for (int i = 0; i < this._layer2DRoots.Length; i++)
			{
				GameObject gameObject = this._layer2DRoots[i];
				int num = 0;
				while (gameObject.transform.childCount > num)
				{
					GameObject gameObject2 = gameObject.transform.GetChild(num).gameObject;
					if (closeGlobal || !gameObject2.CompareTag("GlobalFrame"))
					{
						Object.DestroyImmediate(gameObject2);
					}
					else
					{
						num++;
					}
				}
			}
		}

		// Token: 0x0600A4C9 RID: 42185 RVA: 0x0021EDEE File Offset: 0x0021D1EE
		public void CloseAllFrames(bool closeGlobal = false, bool removeRef = false)
		{
			this._closeAllActiveFrame(closeGlobal, removeRef);
			this._clearAllGameObjects(closeGlobal);
		}

		// Token: 0x0600A4CA RID: 42186 RVA: 0x0021EE00 File Offset: 0x0021D200
		public void UpdateAllFrames(float timeElapsed)
		{
			for (int i = 0; i < this._activeFrames.Count; i++)
			{
				IClientFrame clientFrame = this._activeFrames[i];
				if (clientFrame != null && clientFrame.IsNeedUpdate())
				{
					clientFrame.Update(timeElapsed);
				}
			}
		}

		// Token: 0x0600A4CB RID: 42187 RVA: 0x0021EE50 File Offset: 0x0021D250
		public void CloseFrames()
		{
			DictionaryView<string, IClientFrame>.Enumerator enumerator = this._frameDics.GetEnumerator();
			List<IClientFrame> list = ListPool<IClientFrame>.Get();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, IClientFrame> keyValuePair = enumerator.Current;
				IClientFrame value = keyValuePair.Value;
				if (value.IsNeedClearWhenChangeScene())
				{
					list.Add(value);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				IClientFrame frame = list[i];
				this._closeFrame(frame, false);
			}
			ListPool<IClientFrame>.Release(list);
		}

		// Token: 0x0600A4CC RID: 42188 RVA: 0x0021EED8 File Offset: 0x0021D2D8
		public void ShowFrame(Type targetFrame, Type currentFrame, bool isShow)
		{
			IClientFrame clientFrame = this._getFrameByType(targetFrame);
			if (clientFrame == null)
			{
				return;
			}
			if (!this._checkIsValidType(currentFrame))
			{
				return;
			}
			clientFrame.Show(isShow, currentFrame);
		}

		// Token: 0x0600A4CD RID: 42189 RVA: 0x0021EF0C File Offset: 0x0021D30C
		public void ShowAllFrame(Type currentFrame, bool isShow)
		{
			if (!this._checkIsValidType(currentFrame))
			{
				return;
			}
			foreach (KeyValuePair<string, IClientFrame> keyValuePair in this._frameDics)
			{
				Type type = keyValuePair.Value.GetType();
				if (currentFrame != type)
				{
					this.ShowFrame(type, currentFrame, isShow);
				}
			}
		}

		// Token: 0x0600A4CE RID: 42190 RVA: 0x0021EF68 File Offset: 0x0021D368
		public DictionaryView<string, IClientFrame> GetAllFrames()
		{
			return this._frameDics;
		}

		// Token: 0x0600A4CF RID: 42191 RVA: 0x0021EF70 File Offset: 0x0021D370
		public void Push2FrameStack(IClientFrameStackCmd cmd)
		{
			this.mClientFrameStack.Add(cmd);
		}

		// Token: 0x0600A4D0 RID: 42192 RVA: 0x0021EF7E File Offset: 0x0021D37E
		public void ClearFrameStack()
		{
			this.mClientFrameStack.Clear();
		}

		// Token: 0x0600A4D1 RID: 42193 RVA: 0x0021EF8C File Offset: 0x0021D38C
		private IEnumerator _popAllFrameInStack()
		{
			for (int i = this.mClientFrameStack.Count - 1; i >= 0; i--)
			{
				IClientFrameStackCmd cmd = this.mClientFrameStack[i];
				if (!cmd.Do())
				{
					break;
				}
				yield return Yielders.EndOfFrame;
			}
			this.ClearFrameStack();
			yield break;
		}

		// Token: 0x0600A4D2 RID: 42194 RVA: 0x0021EFA7 File Offset: 0x0021D3A7
		public sealed override void Init()
		{
			this._InitializeAudio();
			this._InitializeUI();
			this._clearMutextFrameHiddenTag();
			this.BindNetEvents();
		}

		// Token: 0x0600A4D3 RID: 42195 RVA: 0x0021EFC4 File Offset: 0x0021D3C4
		public void Update(float timeElapsed)
		{
			this.UpdateSwitchSystemLoadingProcess();
			if (this.CurrentSystem != null)
			{
				this.CurrentSystem.Update(timeElapsed);
			}
			if (this.TargetSystem != null)
			{
				this.TargetSystem.Update(timeElapsed);
			}
			DataManager<WaitNetMessageManager>.GetInstance().Update(timeElapsed);
			Singleton<PlayerDataManager>.GetInstance().Update(timeElapsed);
			this.UpdateAllFrames(timeElapsed);
			DataManager<MissionManager>.GetInstance().Update();
			DataManager<ChatManager>.GetInstance().Update();
			SystemNotifyManager.GetInstance().OnUpdate(timeElapsed);
			DataManager<AnnouncementManager>.GetInstance().OnUpdate(timeElapsed);
			DataManager<TeamDataManager>.GetInstance().OnUpdate(timeElapsed);
			DataManager<RedPointDataManager>.GetInstance().Update(timeElapsed);
			DataManager<ActivityDungeonDataManager>.GetInstance().Update(timeElapsed);
			DataManager<PetDataManager>.GetInstance().OnUpdate(timeElapsed);
			Singleton<LoginPushManager>.GetInstance().OnUpdate(timeElapsed);
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().OnUpdate(timeElapsed);
			if (this.delayCaller != null)
			{
				this.delayCaller.Update((int)(timeElapsed * (float)GlobalLogic.VALUE_1000));
			}
			if (this.mManager != null)
			{
				this.mManager.UpdateEnumerators();
			}
			Singleton<AsyncLoadTaskManager>.instance.Update(timeElapsed);
			this._updateFullScreen(timeElapsed);
		}

		// Token: 0x0600A4D4 RID: 42196 RVA: 0x0021F0D5 File Offset: 0x0021D4D5
		private void _onChangeClear()
		{
			MonoSingleton<AudioFxManager>.instance.Stop();
			ScriptPool.ClearAll();
		}

		// Token: 0x0600A4D5 RID: 42197 RVA: 0x0021F0E8 File Offset: 0x0021D4E8
		public void TryCloseAllFrames()
		{
			this.CloseAllFrames(false, true);
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, IClientFrame> keyValuePair in this._frameDics)
			{
				if (!keyValuePair.Value.IsOpen())
				{
					list.Add(keyValuePair.Key);
				}
			}
			list.RemoveAll(delegate(string x)
			{
				this._frameDics.Remove(x);
				return true;
			});
		}

		// Token: 0x170019BE RID: 6590
		// (get) Token: 0x0600A4D6 RID: 42198 RVA: 0x0021F159 File Offset: 0x0021D559
		public ClientSystemManager.SwitchSystemFinishedEvent OnSwitchSystemFinished
		{
			get
			{
				return this.m_switchFinished;
			}
		}

		// Token: 0x170019BF RID: 6591
		// (get) Token: 0x0600A4D7 RID: 42199 RVA: 0x0021F161 File Offset: 0x0021D561
		public ClientSystemManager.SwitchSystemBeginEvent OnSwitchSystemBegin
		{
			get
			{
				return this.m_switchBegin;
			}
		}

		// Token: 0x170019C0 RID: 6592
		// (get) Token: 0x0600A4D8 RID: 42200 RVA: 0x0021F169 File Offset: 0x0021D569
		public Type PreSystemType
		{
			get
			{
				return this.m_ePreSystemType;
			}
		}

		// Token: 0x170019C1 RID: 6593
		// (get) Token: 0x0600A4D9 RID: 42201 RVA: 0x0021F171 File Offset: 0x0021D571
		public bool isSwitchSystemLoading
		{
			get
			{
				return this.m_switchSystemLoadingCoroutinesLocked;
			}
		}

		// Token: 0x170019C2 RID: 6594
		// (get) Token: 0x0600A4DA RID: 42202 RVA: 0x0021F179 File Offset: 0x0021D579
		public int EnterCoroutineCount
		{
			get
			{
				return this.m_switchSystemLoadingEnterCoroutines.Count;
			}
		}

		// Token: 0x170019C3 RID: 6595
		// (get) Token: 0x0600A4DB RID: 42203 RVA: 0x0021F186 File Offset: 0x0021D586
		public int ExitCoroutineCount
		{
			get
			{
				return this.m_switchSystemLoadingExitCoroutines.Count;
			}
		}

		// Token: 0x170019C4 RID: 6596
		// (get) Token: 0x0600A4DC RID: 42204 RVA: 0x0021F193 File Offset: 0x0021D593
		public float LoadingOPProgress
		{
			get
			{
				return this.switchSystemLoadingOP.GetProgress();
			}
		}

		// Token: 0x0600A4DD RID: 42205 RVA: 0x0021F1A0 File Offset: 0x0021D5A0
		private void BeginSwitchSystemLoading()
		{
			this.switchSystemLoadingOP.ReInit();
			this.SwitchProgress = 0f;
			this.m_bSwitchSystem = true;
			InputManager.isForceLock = true;
		}

		// Token: 0x0600A4DE RID: 42206 RVA: 0x0021F1C5 File Offset: 0x0021D5C5
		public string GetSwitchSystemInfo()
		{
			return this.switchSystemLoadingOP.GetProgressInfo();
		}

		// Token: 0x0600A4DF RID: 42207 RVA: 0x0021F1D2 File Offset: 0x0021D5D2
		private void EndSwitchSystemLoading()
		{
			this.SwitchProgress = 1f;
			this.m_bSwitchSystem = false;
			InputManager.isForceLock = false;
		}

		// Token: 0x0600A4E0 RID: 42208 RVA: 0x0021F1EC File Offset: 0x0021D5EC
		private void UpdateSwitchSystemLoadingProcess()
		{
			if (this.m_bSwitchSystem && this.m_switchSystemLoadingCoroutinesLocked)
			{
				this.SwitchProgress = this.switchSystemLoadingOP.Progress;
			}
		}

		// Token: 0x0600A4E1 RID: 42209 RVA: 0x0021F215 File Offset: 0x0021D615
		private bool AddExitCoroutine(loadingCoroutine coroutine, string name = "", float weight = 1f)
		{
			if (this.m_switchSystemLoadingCoroutinesLocked)
			{
				return false;
			}
			if (coroutine == null)
			{
				return false;
			}
			this.switchSystemLoadingOP.AddTask(name, weight);
			this.m_switchSystemLoadingExitCoroutines.Add(coroutine(this.switchSystemLoadingOP));
			return true;
		}

		// Token: 0x0600A4E2 RID: 42210 RVA: 0x0021F251 File Offset: 0x0021D651
		private bool AddEnterCoroutine(loadingCoroutine coroutine, string name = "", float weight = 1f)
		{
			if (this.m_switchSystemLoadingCoroutinesLocked)
			{
				return false;
			}
			if (coroutine == null)
			{
				return false;
			}
			this.switchSystemLoadingOP.AddTask(name, weight);
			this.m_switchSystemLoadingEnterCoroutines.Add(coroutine(this.switchSystemLoadingOP));
			return true;
		}

		// Token: 0x0600A4E3 RID: 42211 RVA: 0x0021F290 File Offset: 0x0021D690
		public void InitSystem<T>(params object[] userData) where T : class, IClientSystem
		{
			if (this.CurrentSystem != null)
			{
				Logger.LogError("初始化系统初始系统必须为空");
			}
			Type typeFromHandle = typeof(T);
			IClientSystem currentSystem = null;
			this._clientSystems.TryGetValue(typeFromHandle.Name, out currentSystem);
			this.CurrentSystem = currentSystem;
			if (this.CurrentSystem == null)
			{
				this.CurrentSystem = Activator.CreateInstance<T>();
				ClientSystem clientSystem = this.CurrentSystem as ClientSystem;
				clientSystem.SystemManager = this;
				clientSystem.SetName(typeFromHandle.Name);
				this._clientSystems.Add(typeFromHandle.Name, this.CurrentSystem);
			}
			(this.CurrentSystem as ClientSystem).OnEnterSystem();
		}

		// Token: 0x0600A4E4 RID: 42212 RVA: 0x0021F33C File Offset: 0x0021D73C
		public void SwitchSystem<T>(SystemContent systemContent = null, object userData = null, bool isAllowWwitchSameSystem = false) where T : class, IClientSystem
		{
			if (!isAllowWwitchSameSystem && this.CurrentSystem != null && this.CurrentSystem.GetType() == typeof(T))
			{
				return;
			}
			if (this.TargetSystem != null)
			{
				return;
			}
			Type typeFromHandle = typeof(T);
			IClientSystem targetSystem = null;
			this._clientSystems.TryGetValue(typeFromHandle.Name, out targetSystem);
			this.TargetSystem = targetSystem;
			if (this.TargetSystem == null)
			{
				this.TargetSystem = Activator.CreateInstance<T>();
				ClientSystem clientSystem = this.TargetSystem as ClientSystem;
				clientSystem.SystemManager = this;
				clientSystem.SetName(typeFromHandle.Name);
				this._clientSystems.Add(typeFromHandle.Name, this.TargetSystem);
			}
			this._onChangeClear();
			if (Global.Settings.startSystem == EClientSystem.Battle)
			{
				DataManager<PlayerBaseData>.GetInstance().Level = (ushort)Global.Settings.TestLevel;
			}
			this.m_ePreSystemType = ((this.CurrentSystem != null) ? this.CurrentSystem.GetType() : null);
			if (isAllowWwitchSameSystem || this.CurrentSystem != this.TargetSystem)
			{
				if (this.TargetSystem != null)
				{
					this.TargetSystem.BeforeEnter();
				}
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._SwitchSystemCoroutine(systemContent));
			}
		}

		// Token: 0x0600A4E5 RID: 42213 RVA: 0x0021F486 File Offset: 0x0021D886
		public void QuitToLoginSystem(int id)
		{
			if (!this.m_beQuitToLogin)
			{
				this.m_beQuitToLogin = true;
				SystemNotifyManager.SystemNotifyOkCancel(id, new UnityAction(this._QuitToLoginImpl), null, FrameLayer.TopMost, false);
			}
		}

		// Token: 0x0600A4E6 RID: 42214 RVA: 0x0021F4AF File Offset: 0x0021D8AF
		public void QuitToLogin(string message)
		{
		}

		// Token: 0x0600A4E7 RID: 42215 RVA: 0x0021F4B4 File Offset: 0x0021D8B4
		private void _forceQuitTargetSystem()
		{
			if (this.TargetSystem != null)
			{
				ClientSystem clientSystem = this.TargetSystem as ClientSystem;
				if (clientSystem != null)
				{
					clientSystem.OnExitSystem();
				}
				this.CurrentSystem = this.TargetSystem;
				this.TargetSystem = null;
				this.m_switchSystemLoadingCoroutinesLocked = false;
			}
		}

		// Token: 0x0600A4E8 RID: 42216 RVA: 0x0021F500 File Offset: 0x0021D900
		public void _QuitToLoginImpl()
		{
			this.m_beQuitToLogin = false;
			this.delayCaller.Clear();
			ClientApplication.playerinfo.state = PlayerState.LOGOUT;
			if (this.CurrentSystem is ClientSystemVersion)
			{
				Singleton<SystemSwitchEventManager>.GetInstance().TriggerEvent(SystemEventType.SYSTEM_EVENT_ON_SWITCH_FAILED);
				return;
			}
			if (this.CurrentSystem is ClientSystemLogin)
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<CreateActorFrame>(null, false);
				Singleton<ClientSystemManager>.instance.CloseFrame<SelectRoleFrame>(null, false);
				Singleton<ClientSystemManager>.instance.CloseFrame<ServerWaitQueueUp>(null, false);
				Singleton<ClientSystemManager>.instance.CloseFrame<ServerListFrame>(null, false);
				Singleton<ClientReconnectManager>.instance.Clear();
				NetManager.Instance().Disconnect(ServerType.GATE_SERVER);
				NetManager.Instance().Disconnect(ServerType.RELAY_SERVER);
				Singleton<SystemSwitchEventManager>.GetInstance().TriggerEvent(SystemEventType.SYSTEM_EVENT_ON_SWITCH_FAILED);
				return;
			}
			this._forceQuitTargetSystem();
			Singleton<ClientReconnectManager>.instance.Clear();
			ComTalk.ForceDestroy();
			Singleton<SDKVoiceManager>.GetInstance().LeaveVoiceSDK(true);
			UIEventSystem.GetInstance().Clear();
			GlobalEventSystem.GetInstance().Clear();
			InvokeMethod.Exit();
			Logger.LogErrorFormat("===================[开始停止所有协程]=======================", new object[0]);
			MonoSingleton<GameFrameWork>.instance.StopAllCoroutines();
			if (this.mManager != null)
			{
				this.mManager.ClearAllEnumerators();
			}
			Logger.LogErrorFormat("===================[结束停止所有协程]=======================", new object[0]);
			Singleton<PlayerDataManager>.GetInstance().ClearAll();
			SystemNotifyManager.Clear();
			ChapterChange.UnInit();
			this.ClearFrameStack();
			if (this.CurrentSystem is ClientSystemLogin)
			{
				this._closeAllActiveFrame(true, true);
				NetManager.Instance().Disconnect(ServerType.GATE_SERVER);
				NetManager.Instance().Disconnect(ServerType.RELAY_SERVER);
			}
			else
			{
				this.CloseAllFrames(true, true);
				NetManager.Instance().Disconnect(ServerType.GATE_SERVER);
				NetManager.Instance().Disconnect(ServerType.RELAY_SERVER);
				NetProcess.Instance().Clear();
			}
			this._frameDics.Clear();
			Singleton<PluginManager>.GetInstance().BuglySceneInfo = string.Empty;
			this.SwitchSystem<ClientSystemVersion>(null, null, false);
		}

		// Token: 0x0600A4E9 RID: 42217 RVA: 0x0021F6CC File Offset: 0x0021DACC
		public void _QuitToSelectRoleImpl()
		{
			this.delayCaller.Clear();
			this._forceQuitTargetSystem();
			Singleton<ClientReconnectManager>.instance.Clear();
			ComTalk.ForceDestroy();
			Singleton<PlayerDataManager>.GetInstance().ClearAll();
			Singleton<NewbieGuideManager>.GetInstance().Reset();
			DataManager<AnnouncementManager>.GetInstance().Clear();
			SystemNotifyManager.Clear();
			ChapterChange.UnInit();
			InvokeMethod.Exit();
			Logger.LogErrorFormat("===================[开始停止所有协程]=======================", new object[0]);
			MonoSingleton<GameFrameWork>.instance.StopAllCoroutines();
			if (this.mManager != null)
			{
				this.mManager.ClearAllEnumerators();
			}
			Logger.LogErrorFormat("===================[结束停止所有协程]=======================", new object[0]);
			this.ClearFrameStack();
			this.CloseAllFrames(true, true);
			this._frameDics.Clear();
			Singleton<PluginManager>.GetInstance().BuglySceneInfo = string.Empty;
			this.SwitchSystem<ClientSystemLogin>(null, null, false);
		}

		// Token: 0x170019C5 RID: 6597
		// (get) Token: 0x0600A4EA RID: 42218 RVA: 0x0021F797 File Offset: 0x0021DB97
		public IEnumeratorManager enumeratorManager
		{
			get
			{
				return this.mManager;
			}
		}

		// Token: 0x0600A4EB RID: 42219 RVA: 0x0021F7A0 File Offset: 0x0021DBA0
		public static IEnumerator _PreloadRes(IASyncOperation op)
		{
			HGProfiler.BeginProfiler("5---preload all res");
			int preloadPercentage = 0;
			while (preloadPercentage < 100)
			{
				preloadPercentage = MonoSingleton<CResPreloader>.instance.DoPreLoadAsync(true, false);
				op.SetProgress(0.5f + (float)preloadPercentage * 0.01f * 0.2f);
				yield return Yielders.EndOfFrame;
			}
			HGProfiler.EndProfiler();
			HGProfiler.EndProfiler();
			yield break;
		}

		// Token: 0x0600A4EC RID: 42220 RVA: 0x0021F7BC File Offset: 0x0021DBBC
		private IEnumerator _SwitchSystemCoroutine(SystemContent systemContent)
		{
			this._isLoading = true;
			this.SendSceneNotifyLoadingInfoBySwitchSystem();
			bool bPKLoading = this._TryOpenPkLoadingFrame(this.CurrentSystem, this.TargetSystem);
			if (bPKLoading)
			{
				yield return this._ShowPKLoadingFrame();
			}
			this.BeginSwitchSystemLoading();
			this.m_switchBegin.Invoke();
			this.m_LoadingStep = 1;
			IClientFrame loadingFrame = this._OpenGlobalLoadingFrame(this.CurrentSystem, this.TargetSystem);
			this.m_LoadingStep = 2;
			yield return new WaitClientFrameOpen(loadingFrame);
			this.m_LoadingStep = 3;
			if (loadingFrame != null)
			{
				yield return loadingFrame.LoadingOpenPost();
			}
			this.m_LoadingStep = 4;
			this.m_switchSystemLoadingExitCoroutines.Clear();
			this.m_switchSystemLoadingEnterCoroutines.Clear();
			if (this.CurrentSystem != null)
			{
				this.CurrentSystem.GetExitCoroutine(new AddCoroutine(this.AddExitCoroutine));
			}
			this.m_LoadingStep = 5;
			if (this.TargetSystem != null)
			{
				this.TargetSystem.GetEnterCoroutine(new AddCoroutine(this.AddEnterCoroutine));
			}
			this.m_LoadingStep = 6;
			this.m_switchSystemLoadingCoroutinesLocked = true;
			int exitCoroutinesCount = this.m_switchSystemLoadingExitCoroutines.Count;
			for (int i = 0; i < this.m_switchSystemLoadingExitCoroutines.Count; i++)
			{
				this.switchSystemLoadingOP.BeginTask(i);
				yield return this.m_switchSystemLoadingExitCoroutines[i];
				this.switchSystemLoadingOP.FinishTask(i);
			}
			this.m_switchSystemLoadingExitCoroutines.Clear();
			this.m_LoadingStep = 7;
			if (this.CurrentSystem != null)
			{
				(this.CurrentSystem as ClientSystem).OnExitSystem();
			}
			this.m_LoadingStep = 8;
			this.TryCloseAllFrames();
			this.m_LoadingStep = 9;
			ComTalk.ForceDestroy();
			this.m_LoadingStep = 10;
			MonoSingleton<CResPreloader>.instance.Clear(true);
			this.m_LoadingStep = 11;
			for (int j = 0; j < this.m_switchSystemLoadingEnterCoroutines.Count; j++)
			{
				this.switchSystemLoadingOP.BeginTask(j + exitCoroutinesCount);
				yield return this.m_switchSystemLoadingEnterCoroutines[j];
				this.switchSystemLoadingOP.FinishTask(j + exitCoroutinesCount);
			}
			this.m_switchSystemLoadingEnterCoroutines.Clear();
			this.m_LoadingStep = 12;
			this.CurrentSystem = this.TargetSystem;
			this.TargetSystem = null;
			this.m_beQuitToLogin = false;
			this.m_switchSystemLoadingCoroutinesLocked = false;
			this.SwitchProgress = 1f;
			this.m_LoadingStep = 13;
			if (this.CurrentSystem != null)
			{
				(this.CurrentSystem as ClientSystem).OnEnterSystem();
			}
			this.m_LoadingStep = 14;
			this.m_switchFinished.Invoke();
			this.m_LoadingStep = 15;
			this.EndSwitchSystemLoading();
			this.m_LoadingStep = 16;
			yield return new WaitClientFrameClose(loadingFrame);
			this.m_LoadingStep = 17;
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._popAllFrameInStack());
			this.m_LoadingStep = 18;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SystemChanged, null, null, null, null);
			this.m_LoadingStep = 19;
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.SystemChanged, null, null, null, null);
			this.m_LoadingStep = 20;
			if (this.CurrentSystem != null)
			{
				(this.CurrentSystem as ClientSystem).OnStartSystem(systemContent);
			}
			this.m_LoadingStep = 21;
			yield return Yielders.GetWaitForSeconds(0.5f);
			this._isLoading = false;
			this.m_LoadingStep = 22;
			this.SendSceneNotifyLoadingInfoBySwitchSystem();
			this.m_LoadingStep = 23;
			this.SyncMainPlayerBaseDataBySwitchSystemFinished();
			this.m_LoadingStep = 24;
			if (this.CurrentSystem != null && this.CurrentSystem is ClientSystemTown)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3CrossButton, (byte)DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus(), null, null, null);
			}
			yield break;
		}

		// Token: 0x0600A4ED RID: 42221 RVA: 0x0021F7E0 File Offset: 0x0021DBE0
		private bool _TryOpenPkLoadingFrame(IClientSystem current, IClientSystem target)
		{
			if (target == null)
			{
				return false;
			}
			Type type = target.GetType();
			Type typeFromHandle = typeof(ClientSystemLogin);
			Type typeFromHandle2 = typeof(ClientSystemTown);
			Type typeFromHandle3 = typeof(ClientSystemBattle);
			Type typeFromHandle4 = typeof(ClientSystemGameBattle);
			if (current == null)
			{
				return false;
			}
			Type type2 = current.GetType();
			if ((type2 == typeFromHandle2 || type2 == typeFromHandle4) && type == typeFromHandle3)
			{
				if (BattleMain.instance == null)
				{
					return false;
				}
				BattleType battleType = BattleMain.battleType;
				if (battleType == BattleType.GuildPVP || battleType == BattleType.MoneyRewardsPVP || battleType == BattleType.MutiPlayer || battleType == BattleType.ChijiPVP)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A4EE RID: 42222 RVA: 0x0021F890 File Offset: 0x0021DC90
		private IEnumerator _ShowPKLoadingFrame()
		{
			PkLoadingFrame pkloading = this.OpenGlobalFrame<PkLoadingFrame>(FrameLayer.Top, null) as PkLoadingFrame;
			yield return pkloading.LoadStartLoading();
			yield break;
		}

		// Token: 0x0600A4EF RID: 42223 RVA: 0x0021F8AC File Offset: 0x0021DCAC
		private IEnumerator _EnterPK()
		{
			PkLoadingFrame pkloading = this._getFrameByType(typeof(PkLoadingFrame)) as PkLoadingFrame;
			if (pkloading != null)
			{
				yield return Yielders.GetWaitForSeconds(2f);
			}
			yield break;
		}

		// Token: 0x0600A4F0 RID: 42224 RVA: 0x0021F8C8 File Offset: 0x0021DCC8
		private IEnumerator _EnterPK2()
		{
			yield return Yielders.GetWaitForSeconds(2f);
			yield return Yielders.EndOfFrame;
			yield return Yielders.GetWaitForSeconds(10000f);
			yield break;
		}

		// Token: 0x0600A4F1 RID: 42225 RVA: 0x0021F8DC File Offset: 0x0021DCDC
		private IClientFrame _OpenGlobalLoadingFrame(IClientSystem current, IClientSystem target)
		{
			if (target == null)
			{
				return null;
			}
			Type type = target.GetType();
			Type typeFromHandle = typeof(ClientSystemLogin);
			Type typeFromHandle2 = typeof(ClientSystemTown);
			Type typeFromHandle3 = typeof(ClientSystemBattle);
			Type typeFromHandle4 = typeof(ClientSystemGameBattle);
			if (current == null)
			{
				if (type == typeFromHandle3)
				{
					return this.OpenGlobalFrame<DungeonLoadingFrame>(FrameLayer.Top, null);
				}
				return this.OpenGlobalFrame<SplashLoadingFrame>(FrameLayer.Top, null);
			}
			else
			{
				Type type2 = current.GetType();
				if (type2 == typeFromHandle && type == typeFromHandle2)
				{
					return this.OpenGlobalFrame<LoadingFrame>(FrameLayer.Top, null);
				}
				if (type2 == typeFromHandle && type == typeFromHandle3)
				{
					return this.OpenGlobalFrame<DungeonLoadingFrame>(FrameLayer.Top, DataManager<PlayerBaseData>.GetInstance().JobTableID);
				}
				if ((type2 == typeFromHandle2 && type == typeFromHandle3) || (type2 == typeFromHandle2 && type == typeFromHandle4) || (type2 == typeFromHandle3 && type == typeFromHandle3) || (type2 == typeFromHandle4 && type == typeFromHandle3))
				{
					if (BattleMain.instance == null)
					{
						return this.OpenGlobalFrame<DungeonLoadingFrame>(FrameLayer.Top, null);
					}
					switch (BattleMain.battleType)
					{
					case BattleType.Single:
						return this.OpenGlobalFrame<LoadingFrame>(FrameLayer.Top, null);
					case BattleType.MutiPlayer:
					case BattleType.ChijiPVP:
						return this.GetFrame(typeof(PkLoadingFrame));
					case BattleType.Dungeon:
					case BattleType.DeadTown:
					case BattleType.Mou:
					case BattleType.North:
					case BattleType.ChampionMatch:
					case BattleType.FinalTestBattle:
						return this.OpenGlobalFrame<DungeonLoadingFrame>(FrameLayer.Top, null);
					case BattleType.NewbieGuide:
						return this.OpenGlobalFrame<DungeonLoadingFrame>(FrameLayer.Top, null);
					case BattleType.GuildPVP:
					case BattleType.MoneyRewardsPVP:
						return this.GetFrame(typeof(PkLoadingFrame));
					case BattleType.PVP3V3Battle:
					case BattleType.ScufflePVP:
						return this.OpenGlobalFrame<Dungeon3v3LoadingFrame>(FrameLayer.Top, null);
					case BattleType.GuildPVE:
						return this.OpenGlobalFrame<DungeonLoadingFrame>(FrameLayer.Top, null);
					}
					return this.OpenGlobalFrame<DungeonLoadingFrame>(FrameLayer.Top, null);
				}
				else
				{
					if (type2 == typeFromHandle2 && type == typeFromHandle)
					{
						return this.OpenGlobalFrame<SplashLoadingFrame>(FrameLayer.Top, null);
					}
					if ((type2 != typeFromHandle3 || type != typeFromHandle2) && (type2 != typeFromHandle4 || type != typeFromHandle2) && (type2 != typeFromHandle3 || type != typeFromHandle4))
					{
						return this.OpenGlobalFrame<SplashLoadingFrame>(FrameLayer.Top, null);
					}
					if (BattleMain.instance != null && BattleMain.battleType == BattleType.NewbieGuide)
					{
						return this.OpenGlobalFrame<LoadingFrame>(FrameLayer.Top, null);
					}
					return this.OpenGlobalFrame<LoadingFrame>(FrameLayer.Top, type);
				}
			}
		}

		// Token: 0x0600A4F2 RID: 42226 RVA: 0x0021FB10 File Offset: 0x0021DF10
		[Conditional("WORD_DEBUG")]
		[Conditional("LOG_DIALOG")]
		[Conditional("LOG_ERROR")]
		[Conditional("LOG_WARNING")]
		[Conditional("LOG_NORMAL")]
		private void _InitializeCUDLRServer()
		{
			GameObject gameObject = Utility.FindGameObject("CUDLRServer", false);
			if (gameObject == null)
			{
				gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/CUDLR/CUDLRServer", true, 0U);
				gameObject.name = "CUDLRServer";
				gameObject.transform.SetAsLastSibling();
				gameObject.SetActive(true);
				Object.DontDestroyOnLoad(gameObject);
			}
		}

		// Token: 0x0600A4F3 RID: 42227 RVA: 0x0021FB6C File Offset: 0x0021DF6C
		[Conditional("DEBUG_REPORT_ROOT")]
		private void _InitializeDebugReportRoot()
		{
			GameObject gameObject = Utility.FindGameObject("__DebugReportRoot", false);
			if (gameObject == null)
			{
				gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/DebugReport/DebugReport", true, 0U);
				gameObject.name = "__DebugReportRoot";
				gameObject.transform.SetAsLastSibling();
				Object.DontDestroyOnLoad(gameObject);
			}
		}

		// Token: 0x0600A4F4 RID: 42228 RVA: 0x0021FBC0 File Offset: 0x0021DFC0
		public GameObject PlayUIEffect(FrameLayer layer, string prefab, float time = 0f)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefab, true, 0U);
			if (gameObject != null)
			{
				gameObject.transform.SetParent(this.LayerRoots[(int)layer].transform, false);
			}
			if (gameObject != null && time != 0f)
			{
				DestroyDelay destroyDelay = gameObject.GetComponent<DestroyDelay>();
				if (null == destroyDelay)
				{
					destroyDelay = gameObject.AddComponent<DestroyDelay>();
				}
				destroyDelay.Delay = time;
			}
			return gameObject;
		}

		// Token: 0x0600A4F5 RID: 42229 RVA: 0x0021FC39 File Offset: 0x0021E039
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(500118U, new Action<MsgDATA>(this.NetSceneQueryLoadingInfo));
		}

		// Token: 0x0600A4F6 RID: 42230 RVA: 0x0021FC51 File Offset: 0x0021E051
		public sealed override void UnInit()
		{
			base.UnInit();
			this.UnBindNetEvents();
		}

		// Token: 0x0600A4F7 RID: 42231 RVA: 0x0021FC5F File Offset: 0x0021E05F
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(500118U, new Action<MsgDATA>(this.NetSceneQueryLoadingInfo));
		}

		// Token: 0x0600A4F8 RID: 42232 RVA: 0x0021FC78 File Offset: 0x0021E078
		private void NetSceneQueryLoadingInfo(MsgDATA msgData)
		{
			if (msgData == null)
			{
				Logger.LogErrorFormat("NetSceneQueryLoadingInfo ==> msgData is null", new object[0]);
				return;
			}
			if (this._isLoading)
			{
				this.SendSceneNotifyLoadingInfo();
			}
			else
			{
				ClientSystemTown clientSystemTown = this.CurrentSystem as ClientSystemTown;
				if (clientSystemTown == null)
				{
					this.SendSceneNotifyLoadingInfo();
					return;
				}
				if (clientSystemTown.GetTownSceneSwitchState())
				{
					this.SendSceneNotifyLoadingInfoByTownSwitchScene(true);
					return;
				}
				this.SendSceneNotifyLoadingInfo();
			}
		}

		// Token: 0x0600A4F9 RID: 42233 RVA: 0x0021FCE4 File Offset: 0x0021E0E4
		private void SendSceneNotifyLoadingInfoBySwitchSystem()
		{
			this.SendSceneNotifyLoadingInfo();
		}

		// Token: 0x0600A4FA RID: 42234 RVA: 0x0021FCEC File Offset: 0x0021E0EC
		public void SendSceneNotifyLoadingInfoByTownSwitchScene(bool isTownSwitchScene)
		{
			int num = 0;
			if (isTownSwitchScene)
			{
				num = 1;
			}
			SceneNotifyLoadingInfo cmd = new SceneNotifyLoadingInfo
			{
				isLoading = (byte)num
			};
			if (NetManager.Instance() != null)
			{
				NetManager.Instance().SendCommand<SceneNotifyLoadingInfo>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600A4FB RID: 42235 RVA: 0x0021FD30 File Offset: 0x0021E130
		private void SendSceneNotifyLoadingInfo()
		{
			int num = 0;
			if (this._isLoading)
			{
				num = 1;
			}
			SceneNotifyLoadingInfo cmd = new SceneNotifyLoadingInfo
			{
				isLoading = (byte)num
			};
			if (NetManager.Instance() != null)
			{
				NetManager.Instance().SendCommand<SceneNotifyLoadingInfo>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600A4FC RID: 42236 RVA: 0x0021FD7C File Offset: 0x0021E17C
		private void SyncMainPlayerBaseDataBySwitchSystemFinished()
		{
			if (this.CurrentSystem == null)
			{
				return;
			}
			ClientSystemTown clientSystemTown = this.CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SceneChangedLoadingFinish, null, null, null, null);
			if (clientSystemTown.MainPlayer == null)
			{
				return;
			}
			clientSystemTown.MainPlayer.SyncResistMagicValue();
		}

		// Token: 0x04005BEF RID: 23535
		protected DictionaryView<string, IClientSystem> _clientSystems = new DictionaryView<string, IClientSystem>();

		// Token: 0x04005BF5 RID: 23541
		public DelayCaller delayCaller = new DelayCaller();

		// Token: 0x04005BF6 RID: 23542
		public const string kInterfaceName = "GameClient.IClientFrame";

		// Token: 0x04005BF7 RID: 23543
		public const string kGlobalTag = "GlobalFrame";

		// Token: 0x04005BF8 RID: 23544
		public static bool sRemoveRefOnClose;

		// Token: 0x04005BF9 RID: 23545
		private int m_LoadingStep;

		// Token: 0x04005BFA RID: 23546
		protected GameObject _layerRoot;

		// Token: 0x04005BFB RID: 23547
		protected Camera _uiCamera;

		// Token: 0x04005BFC RID: 23548
		protected GameObject[] _layer2DRoots = new GameObject[0];

		// Token: 0x04005BFD RID: 23549
		private GameObject m_objSceneUILayer;

		// Token: 0x04005BFE RID: 23550
		protected Canvas _canvas;

		// Token: 0x04005BFF RID: 23551
		protected GameObject _layer3DRoot;

		// Token: 0x04005C00 RID: 23552
		protected DictionaryView<string, IClientFrame> _frameDics = new DictionaryView<string, IClientFrame>();

		// Token: 0x04005C01 RID: 23553
		protected List<IClientFrame> _activeFrames = new List<IClientFrame>();

		// Token: 0x04005C02 RID: 23554
		protected DictionaryView<string, ClientSystemManager.ClientFrameGroup> _clientGroups = new DictionaryView<string, ClientSystemManager.ClientFrameGroup>();

		// Token: 0x04005C03 RID: 23555
		private int mFullScreenDirtyCount;

		// Token: 0x04005C04 RID: 23556
		private bool mFullScreenDirtyFlag;

		// Token: 0x04005C05 RID: 23557
		private List<IClientFrame> mFullScreenFrames = new List<IClientFrame>();

		// Token: 0x04005C06 RID: 23558
		private List<IClientFrame> mCacheFullScreenFramesToClose = new List<IClientFrame>();

		// Token: 0x04005C07 RID: 23559
		private List<IClientFrameStackCmd> mClientFrameStack = new List<IClientFrameStackCmd>();

		// Token: 0x04005C08 RID: 23560
		protected ClientSystemManager.SwitchSystemFinishedEvent m_switchFinished = new ClientSystemManager.SwitchSystemFinishedEvent();

		// Token: 0x04005C09 RID: 23561
		protected ClientSystemManager.SwitchSystemBeginEvent m_switchBegin = new ClientSystemManager.SwitchSystemBeginEvent();

		// Token: 0x04005C0A RID: 23562
		private Type m_ePreSystemType;

		// Token: 0x04005C0B RID: 23563
		private List<IEnumerator> m_switchSystemLoadingExitCoroutines = new List<IEnumerator>();

		// Token: 0x04005C0C RID: 23564
		private List<IEnumerator> m_switchSystemLoadingEnterCoroutines = new List<IEnumerator>();

		// Token: 0x04005C0D RID: 23565
		private bool m_switchSystemLoadingCoroutinesLocked;

		// Token: 0x04005C0E RID: 23566
		private bool m_bSwitchSystem;

		// Token: 0x04005C0F RID: 23567
		private SystemAsyncOperation switchSystemLoadingOP = new SystemAsyncOperation();

		// Token: 0x04005C10 RID: 23568
		private bool m_beQuitToLogin;

		// Token: 0x04005C11 RID: 23569
		private IEnumeratorManager mManager = new EnumeratorProcessManager();

		// Token: 0x04005C12 RID: 23570
		private const string kDebugReportRootName = "__DebugReportRoot";

		// Token: 0x04005C13 RID: 23571
		private bool _isLoading;

		// Token: 0x020010FD RID: 4349
		protected class ClientFrameGroup
		{
			// Token: 0x0600A4FF RID: 42239 RVA: 0x0021FDE4 File Offset: 0x0021E1E4
			public ClientFrameGroup(string name)
			{
				this.mGroupTag = name;
				this.mClientFrames = new List<string>();
			}

			// Token: 0x0600A500 RID: 42240 RVA: 0x0021FE09 File Offset: 0x0021E209
			public string GroupTag()
			{
				return this.mGroupTag;
			}

			// Token: 0x0600A501 RID: 42241 RVA: 0x0021FE11 File Offset: 0x0021E211
			public string GetHiddentGroup()
			{
				return this.mHiddenTag;
			}

			// Token: 0x0600A502 RID: 42242 RVA: 0x0021FE19 File Offset: 0x0021E219
			public bool IsGroupShow()
			{
				return this.mHiddenTag.Length <= 0;
			}

			// Token: 0x0600A503 RID: 42243 RVA: 0x0021FE2C File Offset: 0x0021E22C
			public void SetHiddenGroup(string tag)
			{
				this.mHiddenTag = tag;
			}

			// Token: 0x0600A504 RID: 42244 RVA: 0x0021FE35 File Offset: 0x0021E235
			public List<string> ClientFrames()
			{
				return this.mClientFrames;
			}

			// Token: 0x04005C14 RID: 23572
			protected string mGroupTag;

			// Token: 0x04005C15 RID: 23573
			protected string mHiddenTag = string.Empty;

			// Token: 0x04005C16 RID: 23574
			protected List<string> mClientFrames;
		}

		// Token: 0x020010FE RID: 4350
		public class SwitchSystemFinishedEvent : UnityEvent
		{
		}

		// Token: 0x020010FF RID: 4351
		public class SwitchSystemBeginEvent : UnityEvent
		{
		}
	}
}
