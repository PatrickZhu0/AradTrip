using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace GameClient
{
	// Token: 0x02001CBD RID: 7357
	internal class TownMapFrame : ClientFrame
	{
		// Token: 0x060120C5 RID: 73925 RVA: 0x00547751 File Offset: 0x00545B51
		protected sealed override void _bindExUI()
		{
			this.mTouchMoveCamera2D = this.mBind.GetCom<TouchMoveCamera2D>("TouchMoveCamera2D");
		}

		// Token: 0x060120C6 RID: 73926 RVA: 0x00547769 File Offset: 0x00545B69
		protected sealed override void _unbindExUI()
		{
			this.mTouchMoveCamera2D = null;
		}

		// Token: 0x060120C7 RID: 73927 RVA: 0x00547772 File Offset: 0x00545B72
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TownMap/Map";
		}

		// Token: 0x060120C8 RID: 73928 RVA: 0x0054777C File Offset: 0x00545B7C
		protected sealed override void _OnLoadPrefabFinish()
		{
			if (base.GetFrameName() != "full_map")
			{
				if (this.mComClienFrame == null)
				{
					this.mComClienFrame = this.frame.AddComponent<ComClientFrame>();
				}
				this.mComClienFrame.SetGroupTag("system");
			}
			if (this.mTouchMoveCamera2D != null)
			{
				this.mTouchMoveCamera2D.bEnabled = (base.GetFrameName() == "full_map");
			}
		}

		// Token: 0x060120C9 RID: 73929 RVA: 0x005477F8 File Offset: 0x00545BF8
		protected sealed override void _OnOpenFrame()
		{
			ClientSystemTown systemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (systemTown == null)
			{
				systemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				if (systemTown == null)
				{
					Logger.LogError("TownMapFrame must open in town system!!");
					return;
				}
			}
			if (BeTownPlayerMain.OnAutoMoveSuccess != null)
			{
				BeTownPlayerMain.OnAutoMoveSuccess.RemoveAllListeners();
				BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(this._OnAutoMoveEnd));
			}
			if (BeTownPlayerMain.OnAutoMoveFail != null)
			{
				BeTownPlayerMain.OnAutoMoveFail.RemoveAllListeners();
				BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(this._OnAutoMoveEnd));
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, "root/scenes", true);
			if (gameObject == null)
			{
				return;
			}
			ComMapScene[] componentsInChildren = gameObject.GetComponentsInChildren<ComMapScene>(true);
			if (componentsInChildren == null)
			{
				Logger.LogError("TownMapFrame Get scenes is null");
				return;
			}
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ComMapScene mapScene = componentsInChildren[i];
				if (!(mapScene == null))
				{
					mapScene.Initialize();
					if (mapScene.btnScene != null)
					{
						mapScene.btnScene.onMouseClick.RemoveAllListeners();
						mapScene.btnScene.onMouseClick.AddListener(delegate(PointerEventData var)
						{
							if (systemTown.MainPlayer != null)
							{
								if ((int)DataManager<PlayerBaseData>.GetInstance().Level < mapScene.levelLimit)
								{
									SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("town_lock_desc", mapScene.sceneName, mapScene.levelLimit), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
								}
								else
								{
									Vector2 zero = Vector2.zero;
									RectTransform component = mapScene.GetComponent<RectTransform>();
									if (component != null)
									{
										RectTransformUtility.ScreenPointToLocalPointInRectangle(component, var.pressPosition, var.enterEventCamera, ref zero);
									}
									Vector3 vector;
									vector..ctor(zero.x / mapScene.XRate, 0f, zero.y / mapScene.ZRate);
									Vector3 a_vecPos = vector + mapScene.offset;
									systemTown.MainPlayer.CommandMoveToScene(mapScene.SceneID, a_vecPos);
									if (this.m_objTargetPos != null)
									{
										this.m_objTargetPos.transform.SetParent(mapScene.transform, false);
										this.m_objTargetPos.transform.localPosition = new Vector3(zero.x, zero.y, 0f);
										this.m_objTargetPos.SetActive(true);
									}
								}
							}
						});
					}
					this._addMapScenes(mapScene);
				}
			}
			this.m_comPlayer = Utility.FindGameObject(this.frame, "root/player_main", true).GetComponent<ComMapPlayer>();
			if (this.m_comPlayer != null)
			{
				this.m_comPlayer.Initialize();
				if (this._containsIdInCurrentTown(systemTown.CurrentSceneID))
				{
					this.m_comPlayer.Setup(systemTown.MainPlayer, this._getMapSceneInCurrentTown(systemTown.CurrentSceneID));
				}
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this._OnSceneChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._OnLevelChanged));
			this._onTownAreaChange(systemTown.CurrentSceneID);
			if (this.mTouchMoveCamera2D != null && this.m_comPlayer != null)
			{
				this.mTouchMoveCamera2D.PlayerTransform = this.m_comPlayer.gameObject.transform;
			}
		}

		// Token: 0x060120CA RID: 73930 RVA: 0x00547A8C File Offset: 0x00545E8C
		private TownMapFrame.MapSceneUnit _getMapSceneUnitByTownId(int townId)
		{
			for (int i = 0; i < this.mMapSceneUnits.Count; i++)
			{
				if (townId == this.mMapSceneUnits[i].TownID)
				{
					return this.mMapSceneUnits[i];
				}
			}
			return null;
		}

		// Token: 0x060120CB RID: 73931 RVA: 0x00547ADC File Offset: 0x00545EDC
		private TownMapFrame.MapSceneUnit _getMapSceneUnitBySceneId(int sceneId)
		{
			int townId = this._getTownID(sceneId);
			return this._getMapSceneUnitByTownId(townId);
		}

		// Token: 0x060120CC RID: 73932 RVA: 0x00547AF8 File Offset: 0x00545EF8
		private TownMapFrame.MapSceneUnit _addMapSceneUnitByTownId(int townId)
		{
			TownMapFrame.MapSceneUnit mapSceneUnit = new TownMapFrame.MapSceneUnit();
			mapSceneUnit.TownID = townId;
			this.mMapSceneUnits.Add(mapSceneUnit);
			return mapSceneUnit;
		}

		// Token: 0x060120CD RID: 73933 RVA: 0x00547B20 File Offset: 0x00545F20
		private TownMapFrame.MapSceneUnit _addMapSceneUnitBySceneId(int sceneId)
		{
			int townId = this._getTownID(sceneId);
			return this._addMapSceneUnitByTownId(townId);
		}

		// Token: 0x060120CE RID: 73934 RVA: 0x00547B3C File Offset: 0x00545F3C
		protected void _addMapScenes(ComMapScene mapScene)
		{
			if (null == mapScene)
			{
				return;
			}
			TownMapFrame.MapSceneUnit mapSceneUnit;
			if (mapScene.JumpTownId != -1)
			{
				mapSceneUnit = this._getMapSceneUnitByTownId(mapScene.JumpTownId);
				if (mapSceneUnit == null)
				{
					mapSceneUnit = this._addMapSceneUnitByTownId(mapScene.JumpTownId);
				}
			}
			else
			{
				mapSceneUnit = this._getMapSceneUnitBySceneId(mapScene.SceneID);
				if (mapSceneUnit == null)
				{
					mapSceneUnit = this._addMapSceneUnitBySceneId(mapScene.SceneID);
				}
			}
			if (mapSceneUnit == null)
			{
				return;
			}
			mapSceneUnit.mapScenes.Add(mapScene.SceneID, mapScene);
		}

		// Token: 0x060120CF RID: 73935 RVA: 0x00547BC4 File Offset: 0x00545FC4
		protected bool _containsIdInCurrentTown(int sceneId)
		{
			Dictionary<int, ComMapScene> dictionary = this._getCurrentTownMapScenesDics();
			return dictionary != null && dictionary.ContainsKey(sceneId);
		}

		// Token: 0x060120D0 RID: 73936 RVA: 0x00547BE8 File Offset: 0x00545FE8
		protected ComMapScene _getMapSceneInCurrentTown(int sceneId)
		{
			if (!this._containsIdInCurrentTown(sceneId))
			{
				return null;
			}
			Dictionary<int, ComMapScene> dictionary = this._getCurrentTownMapScenesDics();
			if (dictionary == null || !dictionary.ContainsKey(sceneId))
			{
				return null;
			}
			return dictionary[sceneId];
		}

		// Token: 0x060120D1 RID: 73937 RVA: 0x00547C28 File Offset: 0x00546028
		protected Dictionary<int, ComMapScene> _getCurrentTownMapScenesDics()
		{
			int townId = this._getCurrentTownID();
			TownMapFrame.MapSceneUnit mapSceneUnit = this._getMapSceneUnitByTownId(townId);
			if (mapSceneUnit == null)
			{
				return null;
			}
			return mapSceneUnit.mapScenes;
		}

		// Token: 0x060120D2 RID: 73938 RVA: 0x00547C54 File Offset: 0x00546054
		protected void _clearMapScenes()
		{
			if (this.mMapSceneUnits != null)
			{
				for (int i = 0; i < this.mMapSceneUnits.Count; i++)
				{
					if (this.mMapSceneUnits[i] != null && this.mMapSceneUnits[i].mapScenes != null)
					{
						this.mMapSceneUnits[i].mapScenes.Clear();
					}
				}
				this.mMapSceneUnits.Clear();
			}
		}

		// Token: 0x060120D3 RID: 73939 RVA: 0x00547CD0 File Offset: 0x005460D0
		protected sealed override void _OnCloseFrame()
		{
			if (BeTownPlayerMain.OnAutoMoveSuccess != null)
			{
				BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this._OnAutoMoveEnd));
			}
			if (BeTownPlayerMain.OnAutoMoveFail != null)
			{
				BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this._OnAutoMoveEnd));
			}
			if (this.m_comPlayer != null)
			{
				this.m_comPlayer = null;
			}
			this._clearMapScenes();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this._OnSceneChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._OnLevelChanged));
		}

		// Token: 0x060120D4 RID: 73940 RVA: 0x00547D6E File Offset: 0x0054616E
		public void SetScale(Vector2 scale)
		{
			this.frame.GetComponent<RectTransform>().localScale = new Vector3(scale.x, scale.y, 1f);
		}

		// Token: 0x060120D5 RID: 73941 RVA: 0x00547D98 File Offset: 0x00546198
		public Vector2 GetSize()
		{
			Vector2 size = this.frame.GetComponent<RectTransform>().rect.size;
			Vector3 localScale = this.frame.GetComponent<RectTransform>().localScale;
			return new Vector2(size.x * localScale.x, size.y * localScale.y);
		}

		// Token: 0x060120D6 RID: 73942 RVA: 0x00547DF4 File Offset: 0x005461F4
		public Vector2 GetPlayerMainPos()
		{
			if (this.m_comPlayer == null)
			{
				return Vector2.zero;
			}
			Vector3 vector = this.m_comPlayer.transform.localPosition + this.m_comPlayer.transform.parent.localPosition;
			Vector3 localScale = this.frame.GetComponent<RectTransform>().localScale;
			return new Vector2(vector.x * localScale.x, vector.y * localScale.y);
		}

		// Token: 0x060120D7 RID: 73943 RVA: 0x00547E77 File Offset: 0x00546277
		public string GetCurrentSceneName()
		{
			if (this.m_comPlayer != null && this.m_comPlayer.isValid)
			{
				return this.m_comPlayer.scene.sceneName;
			}
			return string.Empty;
		}

		// Token: 0x060120D8 RID: 73944 RVA: 0x00547EB0 File Offset: 0x005462B0
		private void _OnAutoMoveEnd()
		{
			this.m_objTargetPos.SetActive(false);
		}

		// Token: 0x060120D9 RID: 73945 RVA: 0x00547EC0 File Offset: 0x005462C0
		protected void _OnSceneChanged(UIEvent uiEvent)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				if (clientSystemTown == null)
				{
					Logger.LogError("TownMapFrame must open in town system!!");
					return;
				}
			}
			this.m_comPlayer.Initialize();
			if (this._containsIdInCurrentTown(clientSystemTown.CurrentSceneID))
			{
				this.m_comPlayer.Setup(clientSystemTown.MainPlayer, this._getMapSceneInCurrentTown(clientSystemTown.CurrentSceneID));
			}
			if (this._hasTownIDChanged(clientSystemTown.CurrentSceneID, clientSystemTown.FromSceneID))
			{
				this._onTownAreaChange(clientSystemTown.CurrentSceneID);
			}
			this.mTouchMoveCamera2D.UpdateMapPos();
		}

		// Token: 0x060120DA RID: 73946 RVA: 0x00547F6C File Offset: 0x0054636C
		protected void _OnLevelChanged(UIEvent a_event)
		{
			Dictionary<int, ComMapScene> dictionary = this._getCurrentTownMapScenesDics();
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<int, ComMapScene> keyValuePair in dictionary)
			{
				ComMapScene value = keyValuePair.Value;
				value.SetLock((int)DataManager<PlayerBaseData>.GetInstance().Level < value.levelLimit);
			}
		}

		// Token: 0x060120DB RID: 73947 RVA: 0x00547FC8 File Offset: 0x005463C8
		private void _onTownAreaChange(int currentSceneId)
		{
			ComMapScene comMapScene = null;
			int num = this._getCurrentTownID();
			for (int i = 0; i < this.mMapSceneUnits.Count; i++)
			{
				bool flag = num == this.mMapSceneUnits[i].TownID;
				if (this.mMapSceneUnits[i].mapScenes != null)
				{
					foreach (KeyValuePair<int, ComMapScene> keyValuePair in this.mMapSceneUnits[i].mapScenes)
					{
						ComMapScene value = keyValuePair.Value;
						if (flag && comMapScene == null)
						{
							comMapScene = value;
						}
						value.CustomActive(flag);
					}
				}
			}
			if (comMapScene != null)
			{
				comMapScene.LoadBackgroundImg();
			}
		}

		// Token: 0x060120DC RID: 73948 RVA: 0x00548094 File Offset: 0x00546494
		private bool _hasTownIDChanged(int currentSceneID, int fromSceneID)
		{
			int num = this._getTownID(currentSceneID);
			if (currentSceneID == -1)
			{
				return false;
			}
			int num2 = this._getTownID(fromSceneID);
			return num2 != -1 && num2 != currentSceneID;
		}

		// Token: 0x060120DD RID: 73949 RVA: 0x005480CC File Offset: 0x005464CC
		private int _getCurrentTownID()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
				if (clientSystemTown == null)
				{
					Logger.LogError("TownMapFrame must open in town system!!");
					return -1;
				}
			}
			return this._getTownID(clientSystemTown.CurrentSceneID);
		}

		// Token: 0x060120DE RID: 73950 RVA: 0x00548120 File Offset: 0x00546520
		private int _getTownID(int sceneID)
		{
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(sceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return -1;
			}
			return tableItem.TownID;
		}

		// Token: 0x0400BC2F RID: 48175
		private TouchMoveCamera2D mTouchMoveCamera2D;

		// Token: 0x0400BC30 RID: 48176
		[UIObject("root/targetPos")]
		private GameObject m_objTargetPos;

		// Token: 0x0400BC31 RID: 48177
		private ComMapPlayer m_comPlayer;

		// Token: 0x0400BC32 RID: 48178
		private List<TownMapFrame.MapSceneUnit> mMapSceneUnits = new List<TownMapFrame.MapSceneUnit>();

		// Token: 0x02001CBE RID: 7358
		private class MapSceneUnit
		{
			// Token: 0x17001DC1 RID: 7617
			// (get) Token: 0x060120E0 RID: 73952 RVA: 0x00548164 File Offset: 0x00546564
			// (set) Token: 0x060120E1 RID: 73953 RVA: 0x0054816C File Offset: 0x0054656C
			public int TownID { get; set; }

			// Token: 0x17001DC2 RID: 7618
			// (get) Token: 0x060120E2 RID: 73954 RVA: 0x00548175 File Offset: 0x00546575
			public Dictionary<int, ComMapScene> mapScenes
			{
				get
				{
					return this.mMapScene;
				}
			}

			// Token: 0x0400BC34 RID: 48180
			private Dictionary<int, ComMapScene> mMapScene = new Dictionary<int, ComMapScene>();
		}
	}
}
