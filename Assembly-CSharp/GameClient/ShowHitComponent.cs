using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200423B RID: 16955
	public class ShowHitComponent
	{
		// Token: 0x06017763 RID: 96099 RVA: 0x0073590C File Offset: 0x00733D0C
		public ShowHitComponent()
		{
			this.RefreshGraphicSetting();
			if (EngineConfig.useNewHitText)
			{
				this.m_TextRendererManger = new TextRendererManager();
				this.m_TextRendererManger.Init();
			}
		}

		// Token: 0x06017764 RID: 96100 RVA: 0x00735A68 File Offset: 0x00733E68
		public ShowHitComponent.HitData GetHitData()
		{
			ShowHitComponent.HitData hitData;
			if (this.hitDataPool.Count > 0)
			{
				hitData = this.hitDataPool.Dequeue();
			}
			else
			{
				hitData = new ShowHitComponent.HitData();
			}
			hitData.Reset();
			return hitData;
		}

		// Token: 0x06017765 RID: 96101 RVA: 0x00735AA6 File Offset: 0x00733EA6
		public void PutHitData(ShowHitComponent.HitData hitData)
		{
			this.hitDataPool.Enqueue(hitData);
		}

		// Token: 0x06017766 RID: 96102 RVA: 0x00735AB4 File Offset: 0x00733EB4
		private void AddHitUpdateList(ShowHitComponent.HitResType type, ShowHitComponent.HitData hitData)
		{
			if (!this.hitUpdateList.ContainsKey((int)type))
			{
				this.hitUpdateList.Add((int)type, new List<ShowHitComponent.HitData>());
			}
			this.hitUpdateList[(int)type].Add(hitData);
		}

		// Token: 0x06017767 RID: 96103 RVA: 0x00735AEC File Offset: 0x00733EEC
		private GameObject GetGameObject(ShowHitComponent.HitResType resPath)
		{
			if (this.hitUpdateList.ContainsKey((int)resPath))
			{
				List<ShowHitComponent.HitData> list = this.hitUpdateList[(int)resPath];
				if (list.Count >= this.ResInfoMap[(int)resPath].maxCount)
				{
					ShowHitComponent.HitData hitData = list[0];
					hitData.Remove();
					list.RemoveAt(0);
				}
			}
			return Singleton<CGameObjectPool>.instance.GetGameObject(this.ResInfoMap[(int)resPath].resPath, enResourceType.BattleScene, 2U);
		}

		// Token: 0x06017768 RID: 96104 RVA: 0x00735B70 File Offset: 0x00733F70
		public void Clear()
		{
			this.ClearHitNumber();
			while (this.hitDataPool.Count > 0)
			{
				ShowHitComponent.HitData hitData = this.hitDataPool.Dequeue();
				hitData.Remove();
			}
			this.hitDataPool.Clear();
			foreach (KeyValuePair<int, List<ShowHitComponent.HitData>> keyValuePair in this.hitUpdateList)
			{
				List<ShowHitComponent.HitData> value = keyValuePair.Value;
				for (int i = 0; i < value.Count; i++)
				{
					value[i].Remove();
				}
			}
			this.hitUpdateList.Clear();
		}

		// Token: 0x06017769 RID: 96105 RVA: 0x00735C16 File Offset: 0x00734016
		public void RefreshGraphicSetting()
		{
			this.isLowGraphic = (Singleton<GeGraphicSetting>.instance.IsLowLevel() && !BattleMain.IsModePvP(BattleMain.battleType));
		}

		// Token: 0x0601776A RID: 96106 RVA: 0x00735C40 File Offset: 0x00734040
		public void Update(int delta)
		{
			if (EngineConfig.useNewHitText)
			{
				this.m_TextRendererManger.Update();
			}
			this.ResetNumber();
			foreach (KeyValuePair<int, List<ShowHitComponent.HitData>> keyValuePair in this.hitUpdateList)
			{
				List<ShowHitComponent.HitData> value = keyValuePair.Value;
				bool flag = false;
				for (int i = 0; i < value.Count; i++)
				{
					value[i].Update(delta);
					if (value[i].canRemove)
					{
						flag = true;
					}
				}
				if (flag)
				{
					value.RemoveAll((ShowHitComponent.HitData item) => item.canRemove);
				}
			}
		}

		// Token: 0x0601776B RID: 96107 RVA: 0x00735D00 File Offset: 0x00734100
		private void _moveUpAllNum(int id, int type, ShowHitComponent.HitData go)
		{
			if (!this.goNumberList.ContainsKey(id))
			{
				this.goNumberList.Add(id, new Dictionary<int, List<ShowHitComponent.HitData>>());
			}
			if (!this.goNumberList[id].ContainsKey(type))
			{
				this.goNumberList[id].Add(type, new List<ShowHitComponent.HitData>());
			}
			this.goNumberList[id][type].Add(go);
			float num = 15f;
			if (type == 5)
			{
				num = 30f;
			}
			for (int i = 0; i < this.goNumberList[id][type].Count; i++)
			{
				ShowHitComponent.HitData hitData = this.goNumberList[id][type][i];
				if (hitData.canRemove)
				{
					this.PutHitData(hitData);
					this.goNumberList[id][type].RemoveAt(i);
					i--;
				}
				else
				{
					GameObject go2 = this.goNumberList[id][type][i].go;
					if (go2 != null)
					{
						Vector3 localPosition = go2.transform.localPosition;
						localPosition.y += num;
						go2.transform.localPosition = localPosition;
					}
				}
			}
		}

		// Token: 0x0601776C RID: 96108 RVA: 0x00735E50 File Offset: 0x00734250
		public void SetHitNumber(GameObject go, int number, List<int> attachNumbers, HitTextType type, ShowHitComponent.HitData hitData = null)
		{
			ComCommonBind component = go.GetComponent<ComCommonBind>();
			GameObject parent = null;
			if (component != null)
			{
				Text com = component.GetCom<Text>("text");
				if (com != null)
				{
					com.text = number.ToString();
					parent = com.gameObject;
				}
				Text com2 = component.GetCom<Text>("textWhite");
				if (com2 != null)
				{
					com2.text = number.ToString();
				}
			}
			if (attachNumbers != null && attachNumbers.Count > 0)
			{
				int num = 0;
				for (int i = 0; i < attachNumbers.Count; i++)
				{
					if (attachNumbers[i] > 0)
					{
						ShowHitComponent.HitResType key = ShowHitComponent.HitResType.NORMAL_ATTACH;
						if (type == HitTextType.NORMAL)
						{
							key = ShowHitComponent.HitResType.NORMAL_ATTACH;
						}
						else if (type == HitTextType.CRITICAL)
						{
							key = ShowHitComponent.HitResType.CRITICAL_ATTACH;
						}
						GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject(this.ResInfoMap[(int)key].resPath, enResourceType.BattleScene, 2U);
						if (gameObject != null)
						{
							hitData.attachGo = gameObject;
						}
						Utility.AttachTo(gameObject, parent, false);
						Vector3 localPosition = gameObject.transform.localPosition;
						localPosition.y -= (float)(20 * num + 10);
						gameObject.transform.localPosition = localPosition;
						this.RunHitNumberAnimation(HitTextAniType.ATTACH, gameObject, hitData);
						if (gameObject != null)
						{
							Text component2 = gameObject.GetComponent<Text>();
							if (null != component2)
							{
								component2.text = attachNumbers[i].ToString();
								hitData.text = component2;
							}
						}
						num++;
					}
				}
			}
		}

		// Token: 0x0601776D RID: 96109 RVA: 0x00736008 File Offset: 0x00734408
		public Vector2 ConvertWorldPosToWorldSpaceCanvas(Vec3 pos)
		{
			Vector2 zero = Vector2.zero;
			if (BattleMain.instance != null)
			{
				if (this.worldCamera == null && BattleMain.instance != null && BattleMain.instance.Main != null && BattleMain.instance.Main.currentGeScene != null && BattleMain.instance.Main.currentGeScene.GetCamera() != null)
				{
					this.worldCamera = BattleMain.instance.Main.currentGeScene.GetCamera().GetCamera();
				}
				if (this.ui3drootRect == null && Singleton<ClientSystemManager>.GetInstance() != null && Singleton<ClientSystemManager>.GetInstance().Layer3DRoot != null)
				{
					this.ui3drootRect = Singleton<ClientSystemManager>.GetInstance().Layer3DRoot.GetComponent<RectTransform>();
				}
				if (this.worldCamera != null && this.ui3drootRect != null)
				{
					Vector2 vector = RectTransformUtility.WorldToScreenPoint(this.worldCamera, new Vector3(pos.x, pos.z, pos.y));
					RectTransformUtility.ScreenPointToLocalPointInRectangle(this.ui3drootRect, vector, this.worldCamera, ref zero);
				}
			}
			return zero;
		}

		// Token: 0x0601776E RID: 96110 RVA: 0x00736140 File Offset: 0x00734540
		public void ShowBuffText(string picName, int id, Vec3 pos, BeActor owner)
		{
			if (EngineConfig.useNewHitText)
			{
				this.ShowBuffTextNew(picName, id, pos, owner);
				return;
			}
			if (this.isLowGraphic && owner != null && owner.m_pkGeActor != null && owner.m_pkGeActor.GetUseCube())
			{
				return;
			}
			ShowHitComponent.HitResType hitResType = ShowHitComponent.HitResType.TEXT_BUFF_NAME;
			GameObject gameObject = this.GetGameObject(hitResType);
			if (gameObject == null)
			{
				return;
			}
			ShowHitComponent.HitData hitData = null;
			int type = 5;
			if (gameObject != null)
			{
				hitData = this.GetHitData();
				hitData.go = gameObject;
				this.AddHitUpdateList(hitResType, hitData);
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component != null)
			{
				Text com = component.GetCom<Text>("text");
				com.text = picName;
			}
			Vector2 vector = this.ConvertWorldPosToWorldSpaceCanvas(pos);
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.Layer3DRoot, false);
			gameObject.transform.localPosition = new Vector3(vector.x, vector.y, -10f);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			this._moveUpAllNum(id, type, hitData);
		}

		// Token: 0x0601776F RID: 96111 RVA: 0x00736260 File Offset: 0x00734660
		public void ShowBuffTextNew(string picName, int id, Vec3 pos, BeActor owner)
		{
			if (this.isLowGraphic && owner != null && owner.m_pkGeActor != null && owner.m_pkGeActor.GetUseCube())
			{
				return;
			}
			ShowHitComponent.HitResType resType = ShowHitComponent.HitResType.TEXT_BUFF_NAME;
			int hitEffectType = 5;
			Vector2 vector = this.ConvertWorldPosToWorldSpaceCanvas(pos);
			this.m_TextRendererManger.AddNameText(picName, new Vec3(vector.x, vector.y, -10f), id, resType, HitTextAniType.BUFFNAME, hitEffectType, 0);
			this.m_TextRendererManger.MoveUpAll(hitEffectType, id, HitTextAniType.BUFFNAME);
		}

		// Token: 0x06017770 RID: 96112 RVA: 0x007362E0 File Offset: 0x007346E0
		public void ResetNumber()
		{
			this.showHitNumberCurFrame = 0;
		}

		// Token: 0x06017771 RID: 96113 RVA: 0x007362EC File Offset: 0x007346EC
		public void ClearHitNumber()
		{
			foreach (KeyValuePair<int, List<ShowHitComponent.HitData>> keyValuePair in this.hitUpdateList)
			{
				List<ShowHitComponent.HitData> value = keyValuePair.Value;
				for (int i = 0; i < value.Count; i++)
				{
					if (!value[i].canRemove)
					{
						value[i].Remove();
					}
				}
			}
			foreach (KeyValuePair<int, Dictionary<int, List<ShowHitComponent.HitData>>> keyValuePair2 in this.goNumberList)
			{
				Dictionary<int, List<ShowHitComponent.HitData>> value2 = keyValuePair2.Value;
				foreach (KeyValuePair<int, List<ShowHitComponent.HitData>> keyValuePair3 in value2)
				{
					List<ShowHitComponent.HitData> value3 = keyValuePair3.Value;
					for (int j = 0; j < value3.Count; j++)
					{
						if (value3[j].canRemove)
						{
							this.PutHitData(value3[j]);
						}
					}
				}
			}
			this.goNumberList.Clear();
		}

		// Token: 0x06017772 RID: 96114 RVA: 0x00736400 File Offset: 0x00734800
		public void ShowHitNumber(int number, List<int> attachNumbers, int id, Vec3 pos, bool isFaceLeft, HitTextType type, BeEntity attacker = null, BeEntity defender = null)
		{
			if (EngineConfig.useNewHitText)
			{
				this.ShowHitNumberNew(number, attachNumbers, id, pos, isFaceLeft, type, attacker, defender);
				return;
			}
			HitTextAniType type2 = HitTextAniType.OTHER;
			this.showHitNumberCurFrame++;
			BeActor beActor = attacker as BeActor;
			BeActor beActor2 = defender as BeActor;
			bool flag = false;
			if (beActor != null)
			{
				bool[] array = new bool[]
				{
					flag
				};
				beActor.TriggerEvent(BeEventType.onChangeHitNumberType, new object[]
				{
					array
				});
				flag = array[0];
			}
			bool flag2 = false;
			ShowHitComponent.HitResType hitResType = ShowHitComponent.HitResType.NORMAL;
			bool flag3 = false;
			if (beActor2 != null && beActor2.isLocalActor)
			{
				switch (type)
				{
				case HitTextType.NORMAL:
				case HitTextType.CRITICAL:
				case HitTextType.BUFF_HURT:
					break;
				default:
					if (type != HitTextType.FRIEND_HURT)
					{
						goto IL_C0;
					}
					break;
				}
				hitResType = ShowHitComponent.HitResType.OWN_HURT;
				type2 = HitTextAniType.OWN;
				flag2 = true;
				IL_C0:;
			}
			else if (beActor != null && (beActor.isLocalActor || flag))
			{
				switch (type)
				{
				case HitTextType.NORMAL:
					flag3 = true;
					type2 = HitTextAniType.NORMAL;
					hitResType = ShowHitComponent.HitResType.NORMAL;
					break;
				case HitTextType.CRITICAL:
					hitResType = ShowHitComponent.HitResType.CRITICAL;
					type2 = HitTextAniType.CRITIAL;
					break;
				default:
					if (type == HitTextType.FRIEND_HURT)
					{
						hitResType = ShowHitComponent.HitResType.FRIEND_HURT;
						type2 = HitTextAniType.FRIEND;
					}
					break;
				case HitTextType.BUFF_HURT:
					type2 = HitTextAniType.BUFF;
					hitResType = ShowHitComponent.HitResType.BUFF_HURT;
					break;
				}
			}
			else
			{
				if (this.isLowGraphic)
				{
					return;
				}
				switch (type)
				{
				case HitTextType.NORMAL:
				case HitTextType.CRITICAL:
					break;
				default:
					if (type != HitTextType.FRIEND_HURT)
					{
						goto IL_179;
					}
					break;
				case HitTextType.BUFF_HURT:
					hitResType = ShowHitComponent.HitResType.BUFF_HURT;
					type2 = HitTextAniType.BUFF;
					goto IL_179;
				}
				hitResType = ShowHitComponent.HitResType.FRIEND_HURT;
				flag2 = true;
				type2 = HitTextAniType.FRIEND;
			}
			IL_179:
			if (type != HitTextType.MISS)
			{
				if (type != HitTextType.RECOVE)
				{
					if (type == HitTextType.MP_RECOVER)
					{
						hitResType = ShowHitComponent.HitResType.TEXT_MP;
					}
				}
				else
				{
					hitResType = ShowHitComponent.HitResType.TEXT_HP;
				}
			}
			else
			{
				hitResType = ShowHitComponent.HitResType.MISS;
				type2 = HitTextAniType.MISS;
			}
			int type3 = 0;
			switch (type)
			{
			case HitTextType.NORMAL:
			case HitTextType.CRITICAL:
				type3 = 1;
				break;
			case HitTextType.BUFF_HURT:
				type3 = 2;
				break;
			case HitTextType.RECOVE:
				type3 = 3;
				break;
			case HitTextType.MP_RECOVER:
				type3 = 4;
				break;
			}
			ShowHitComponent.HitData hitData = null;
			GameObject gameObject = this.GetGameObject(hitResType);
			if (gameObject != null)
			{
				if (flag3)
				{
					this.normalCount++;
				}
				hitData = this.GetHitData();
				hitData.go = gameObject;
				this.AddHitUpdateList(hitResType, hitData);
			}
			if (gameObject == null)
			{
				return;
			}
			if (flag2 && attachNumbers != null && attachNumbers.Count > 0)
			{
				for (int i = 0; i < attachNumbers.Count; i++)
				{
					number += attachNumbers[i];
				}
			}
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.Layer3DRoot, false);
			ShowHitComponent.ORDER++;
			ShowHitComponent.ORDER %= 100;
			pos.z = Mathf.Clamp(pos.z, 0f, 3f);
			Vector2 vector = this.ConvertWorldPosToWorldSpaceCanvas(pos);
			gameObject.transform.localPosition = new Vector3(vector.x, vector.y, -(float)ShowHitComponent.ORDER * 0.625f);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			if (this.showHitNumberCurFrame >= 2)
			{
				Vector3 localPosition = gameObject.transform.localPosition;
				localPosition.y += (float)(40 * (this.showHitNumberCurFrame - 1));
				gameObject.transform.localPosition = localPosition;
			}
			this.RunHitNumberAnimation(type2, gameObject, hitData);
			if (type != HitTextType.MISS)
			{
				this._moveUpAllNum(id, type3, hitData);
				this.SetHitNumber(gameObject, number, attachNumbers, type, hitData);
			}
		}

		// Token: 0x06017773 RID: 96115 RVA: 0x007367A8 File Offset: 0x00734BA8
		public void ShowHitNumberNew(int number, List<int> attachNumbers, int id, Vec3 pos, bool isFaceLeft, HitTextType type, BeEntity attacker = null, BeEntity defender = null)
		{
			if (!this.CheckHitNumIsNeedCreate(attacker, defender))
			{
				return;
			}
			HitTextAniType animType = HitTextAniType.OTHER;
			this.showHitNumberCurFrame++;
			BeActor beActor = attacker as BeActor;
			BeActor beActor2 = defender as BeActor;
			bool flag = false;
			if (beActor != null)
			{
				bool[] array = new bool[]
				{
					flag
				};
				beActor.TriggerEvent(BeEventType.onChangeHitNumberType, new object[]
				{
					array
				});
				flag = array[0];
			}
			bool flag2 = false;
			ShowHitComponent.HitResType resType = ShowHitComponent.HitResType.NORMAL;
			if (beActor2 != null && beActor2.isLocalActor)
			{
				switch (type)
				{
				case HitTextType.NORMAL:
				case HitTextType.CRITICAL:
				case HitTextType.BUFF_HURT:
					resType = ShowHitComponent.HitResType.OWN_HURT;
					animType = HitTextAniType.OWN;
					flag2 = true;
					break;
				default:
					if (type == HitTextType.FRIEND_HURT)
					{
						resType = ShowHitComponent.HitResType.FRIEND_HURT;
						animType = HitTextAniType.FRIEND;
						flag2 = true;
					}
					break;
				}
			}
			else if (beActor != null && (beActor.isLocalActor || flag))
			{
				switch (type)
				{
				case HitTextType.NORMAL:
					animType = HitTextAniType.NORMAL;
					resType = ShowHitComponent.HitResType.NORMAL;
					break;
				case HitTextType.CRITICAL:
					resType = ShowHitComponent.HitResType.CRITICAL;
					animType = HitTextAniType.CRITIAL;
					break;
				default:
					if (type == HitTextType.FRIEND_HURT)
					{
						resType = ShowHitComponent.HitResType.FRIEND_HURT;
						animType = HitTextAniType.FRIEND;
					}
					break;
				case HitTextType.BUFF_HURT:
					animType = HitTextAniType.BUFF;
					resType = ShowHitComponent.HitResType.BUFF_HURT;
					break;
				}
			}
			else
			{
				if (this.isLowGraphic)
				{
					return;
				}
				switch (type)
				{
				case HitTextType.NORMAL:
				case HitTextType.CRITICAL:
					break;
				default:
					if (type != HitTextType.FRIEND_HURT)
					{
						goto IL_175;
					}
					break;
				case HitTextType.BUFF_HURT:
					resType = ShowHitComponent.HitResType.BUFF_HURT;
					animType = HitTextAniType.BUFF;
					goto IL_175;
				}
				resType = ShowHitComponent.HitResType.FRIEND_HURT;
				animType = HitTextAniType.FRIEND;
			}
			IL_175:
			if (type != HitTextType.MISS)
			{
				if (type != HitTextType.RECOVE)
				{
					if (type == HitTextType.MP_RECOVER)
					{
						resType = ShowHitComponent.HitResType.TEXT_MP;
					}
				}
				else
				{
					resType = ShowHitComponent.HitResType.TEXT_HP;
				}
			}
			else
			{
				resType = ShowHitComponent.HitResType.MISS;
				animType = HitTextAniType.MISS;
			}
			int hitEffectType = 0;
			switch (type)
			{
			case HitTextType.NORMAL:
			case HitTextType.CRITICAL:
				hitEffectType = 1;
				break;
			case HitTextType.BUFF_HURT:
				hitEffectType = 2;
				break;
			case HitTextType.RECOVE:
				hitEffectType = 3;
				break;
			case HitTextType.MP_RECOVER:
				hitEffectType = 4;
				break;
			}
			ShowHitComponent.ORDER++;
			ShowHitComponent.ORDER %= 100;
			pos.z = Mathf.Clamp(pos.z, 0f, 3f);
			Vector2 vector = this.ConvertWorldPosToWorldSpaceCanvas(pos);
			if (flag2 && attachNumbers != null && attachNumbers.Count > 0)
			{
				for (int i = 0; i < attachNumbers.Count; i++)
				{
					number += attachNumbers[i];
				}
			}
			this.m_TextRendererManger.AddText(number, new Vec3(vector.x, vector.y + (float)(40 * (this.showHitNumberCurFrame - 1)), -(float)ShowHitComponent.ORDER * 0.625f), id, resType, animType, hitEffectType, 0);
			if (type != HitTextType.MISS && attachNumbers != null && attachNumbers.Count > 0)
			{
				int num = 0;
				for (int j = 0; j < attachNumbers.Count; j++)
				{
					if (attachNumbers[j] > 0)
					{
						ShowHitComponent.HitResType hitResType = ShowHitComponent.HitResType.NORMAL_ATTACH;
						if (type == HitTextType.NORMAL)
						{
							hitResType = ShowHitComponent.HitResType.NORMAL_ATTACH;
						}
						else if (type == HitTextType.CRITICAL)
						{
							hitResType = ShowHitComponent.HitResType.CRITICAL_ATTACH;
						}
						if (hitResType == ShowHitComponent.HitResType.NORMAL_ATTACH)
						{
							switch (resType)
							{
							case ShowHitComponent.HitResType.NORMAL:
								this.m_TextRendererManger.AddText(attachNumbers[j], new Vec3(vector.x, vector.y + (float)(40 * (this.showHitNumberCurFrame - 1)) - (float)(20 * num) * 0.65f + 10f - 15f, -(float)ShowHitComponent.ORDER * 0.625f + 2f), id, hitResType, animType, hitEffectType, 0);
								break;
							case ShowHitComponent.HitResType.OWN_HURT:
								this.m_TextRendererManger.AddText(attachNumbers[j], new Vec3(vector.x - 20f, vector.y + (float)(40 * (this.showHitNumberCurFrame - 1)) - (float)(20 * num) + 10f - 50f, -(float)ShowHitComponent.ORDER * 0.625f + 2f), id, hitResType, animType, hitEffectType, 2);
								break;
							case ShowHitComponent.HitResType.BUFF_HURT:
								this.m_TextRendererManger.AddText(attachNumbers[j], new Vec3(vector.x, vector.y + (float)(40 * (this.showHitNumberCurFrame - 1)) - (float)(20 * num) * 0.7f - 35f, -(float)ShowHitComponent.ORDER * 0.625f + 2f), id, hitResType, animType, hitEffectType, 5);
								break;
							case ShowHitComponent.HitResType.FRIEND_HURT:
								this.m_TextRendererManger.AddText(attachNumbers[j], new Vec3(vector.x, vector.y + (float)(40 * (this.showHitNumberCurFrame - 1)) - (float)(20 * num) + 10f - 20f, -(float)ShowHitComponent.ORDER * 0.625f + 2f), id, hitResType, animType, hitEffectType, 1);
								break;
							case ShowHitComponent.HitResType.TEXT_HP:
								this.m_TextRendererManger.AddText(attachNumbers[j], new Vec3(vector.x - 20f, vector.y + (float)(40 * (this.showHitNumberCurFrame - 1)) - (float)(20 * num) * 0.7f + 10f - 50f, -(float)ShowHitComponent.ORDER * 0.625f + 2f), id, hitResType, animType, hitEffectType, 3);
								break;
							case ShowHitComponent.HitResType.TEXT_MP:
								this.m_TextRendererManger.AddText(attachNumbers[j], new Vec3(vector.x - 20f, vector.y + (float)(40 * (this.showHitNumberCurFrame - 1)) - (float)(20 * num) + 10f - 50f, -(float)ShowHitComponent.ORDER * 0.625f + 2f), id, hitResType, animType, hitEffectType, 4);
								break;
							}
						}
						else if (hitResType == ShowHitComponent.HitResType.CRITICAL_ATTACH)
						{
							this.m_TextRendererManger.AddText(attachNumbers[j], new Vec3(vector.x, vector.y + (float)(40 * (this.showHitNumberCurFrame - 1)) - (float)(20 * num) * 0.73f + 10f, -(float)ShowHitComponent.ORDER * 0.625f + 2f), id, hitResType, animType, hitEffectType, 0);
						}
						num++;
					}
				}
			}
			this.m_TextRendererManger.MoveUpAll(hitEffectType, id, animType);
		}

		// Token: 0x06017774 RID: 96116 RVA: 0x00736E0C File Offset: 0x0073520C
		public void RunHitNumberAnimation(HitTextAniType type, GameObject go, ShowHitComponent.HitData hitData = null)
		{
			if (type != HitTextAniType.NORMAL && type != HitTextAniType.ATTACH && type != HitTextAniType.FRIEND)
			{
				return;
			}
			Text text = null;
			Text text2 = null;
			ComCommonBind component = go.GetComponent<ComCommonBind>();
			GameObject gameObject = null;
			if (component != null)
			{
				text = component.GetCom<Text>("text");
				if (text != null)
				{
					gameObject = text.gameObject;
				}
			}
			if (gameObject != null)
			{
				if (type != HitTextAniType.ATTACH)
				{
					gameObject.transform.localPosition = Vector3.zero;
				}
				Color color = text.color;
				color.a = 1f;
				text.color = color;
			}
			GameObject goWhite = null;
			if (component != null)
			{
				text2 = component.GetCom<Text>("textWhite");
				if (text2 != null)
				{
					goWhite = text2.gameObject;
				}
			}
			if (goWhite != null)
			{
				if (type != HitTextAniType.ATTACH)
				{
					goWhite.transform.localPosition = Vector3.zero;
				}
				Color color = text2.color;
				color.a = 1f;
				text2.color = color;
			}
			if (type == HitTextAniType.NORMAL)
			{
				Vector3 localScale = gameObject.transform.localScale;
				Vector3 originScaleWhite = goWhite.transform.localScale;
				Sequence sequence = DOTween.Sequence();
				TweenSettingsExtensions.Append(sequence, ShortcutExtensions.DOScale(goWhite.transform, 0.7f, 0.2f));
				TweenSettingsExtensions.Join(sequence, ShortcutExtensions46.DOFade(text, 0f, 0.01f));
				TweenSettingsExtensions.Append(sequence, ShortcutExtensions46.DOFade(text2, 0f, 0.01f));
				TweenSettingsExtensions.AppendCallback(sequence, delegate()
				{
					goWhite.transform.localScale = originScaleWhite;
				});
				TweenSettingsExtensions.Append(sequence, ShortcutExtensions46.DOFade(text, 1f, 0.01f));
				TweenSettingsExtensions.Append(sequence, ShortcutExtensions.DOLocalMoveY(gameObject.transform, 25f, 0.7f, false));
				TweenSettingsExtensions.Append(sequence, ShortcutExtensions46.DOFade(text, 0f, 0.08f));
				TweenSettingsExtensions.Join(sequence, ShortcutExtensions.DOLocalMoveY(gameObject.transform, 25f, 0.08f, false));
				if (hitData != null)
				{
					hitData.tween = sequence;
				}
			}
			else if (type == HitTextAniType.FRIEND)
			{
				Sequence sequence2 = DOTween.Sequence();
				TweenSettingsExtensions.Append(sequence2, ShortcutExtensions46.DOFade(text, 1f, 0.01f));
				TweenSettingsExtensions.Append(sequence2, ShortcutExtensions.DOLocalMoveY(gameObject.transform, 25f, 0.7f, false));
				TweenSettingsExtensions.Append(sequence2, ShortcutExtensions46.DOFade(text, 0f, 0.08f));
				TweenSettingsExtensions.Join(sequence2, ShortcutExtensions.DOLocalMoveY(gameObject.transform, 25f, 0.08f, false));
				if (hitData != null)
				{
					hitData.tween = sequence2;
				}
			}
			else if (type == HitTextAniType.ATTACH)
			{
				Sequence sequence3 = DOTween.Sequence();
				TweenSettingsExtensions.Append(sequence3, ShortcutExtensions46.DOFade(text, 1f, 0.01f));
				TweenSettingsExtensions.AppendInterval(sequence3, 0.9f);
				TweenSettingsExtensions.Append(sequence3, ShortcutExtensions46.DOFade(text, 0f, 0.08f));
				if (hitData != null)
				{
					hitData.attachTween = sequence3;
				}
			}
		}

		// Token: 0x06017775 RID: 96117 RVA: 0x00737144 File Offset: 0x00735544
		private bool CheckHitNumIsNeedCreate(BeEntity attacker, BeEntity target)
		{
			if (BattleMain.instance == null)
			{
				return true;
			}
			if (BattleMain.IsModePvP(BattleMain.battleType))
			{
				return true;
			}
			if (Singleton<SettingManager>.instance.GetCommmonSet("SETTING_HITNUMSET") != SettingManager.SetCommonType.Close)
			{
				return true;
			}
			if (attacker == null)
			{
				return true;
			}
			BeActor beActor = attacker.GetTopOwner(attacker) as BeActor;
			if (beActor != null && beActor.isLocalActor)
			{
				return true;
			}
			BeActor beActor2 = target as BeActor;
			return beActor2 != null && beActor2.isLocalActor;
		}

		// Token: 0x04010D96 RID: 69014
		private int showHitNumberCurFrame;

		// Token: 0x04010D97 RID: 69015
		private Camera worldCamera;

		// Token: 0x04010D98 RID: 69016
		private RectTransform ui3drootRect;

		// Token: 0x04010D99 RID: 69017
		private static int ORDER;

		// Token: 0x04010D9A RID: 69018
		private Dictionary<int, Dictionary<int, List<ShowHitComponent.HitData>>> goNumberList = new Dictionary<int, Dictionary<int, List<ShowHitComponent.HitData>>>();

		// Token: 0x04010D9B RID: 69019
		private Dictionary<int, List<ShowHitComponent.HitData>> hitUpdateList = new Dictionary<int, List<ShowHitComponent.HitData>>();

		// Token: 0x04010D9C RID: 69020
		private Queue<ShowHitComponent.HitData> hitDataPool = new Queue<ShowHitComponent.HitData>();

		// Token: 0x04010D9D RID: 69021
		private static int MAX_GO_COUNT = 25;

		// Token: 0x04010D9E RID: 69022
		public Dictionary<int, ShowHitComponent.ResTypeInfo> ResInfoMap = new Dictionary<int, ShowHitComponent.ResTypeInfo>
		{
			{
				0,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/NormalHurtText", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				1,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/CriticleHurtText", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				3,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/TextHurtOwn", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				4,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/TextBuffHurt", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				5,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/TextHurtFriend", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				2,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/MissText", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				6,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/TextHP", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				7,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/TextMP", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				8,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/TextBuffName", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				9,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/NormalAttachText", ShowHitComponent.MAX_GO_COUNT)
			},
			{
				10,
				new ShowHitComponent.ResTypeInfo("UIFlatten/Prefabs/Battle_Digit/CriticleAttachText", ShowHitComponent.MAX_GO_COUNT)
			}
		};

		// Token: 0x04010D9F RID: 69023
		private TextRendererManager m_TextRendererManger;

		// Token: 0x04010DA0 RID: 69024
		private static int poolCount;

		// Token: 0x04010DA1 RID: 69025
		private bool isLowGraphic;

		// Token: 0x04010DA2 RID: 69026
		private int normalCount;

		// Token: 0x0200423C RID: 16956
		public enum HitResType
		{
			// Token: 0x04010DA5 RID: 69029
			NORMAL,
			// Token: 0x04010DA6 RID: 69030
			CRITICAL,
			// Token: 0x04010DA7 RID: 69031
			MISS,
			// Token: 0x04010DA8 RID: 69032
			OWN_HURT,
			// Token: 0x04010DA9 RID: 69033
			BUFF_HURT,
			// Token: 0x04010DAA RID: 69034
			FRIEND_HURT,
			// Token: 0x04010DAB RID: 69035
			TEXT_HP,
			// Token: 0x04010DAC RID: 69036
			TEXT_MP,
			// Token: 0x04010DAD RID: 69037
			TEXT_BUFF_NAME,
			// Token: 0x04010DAE RID: 69038
			NORMAL_ATTACH,
			// Token: 0x04010DAF RID: 69039
			CRITICAL_ATTACH
		}

		// Token: 0x0200423D RID: 16957
		public struct ResTypeInfo
		{
			// Token: 0x06017778 RID: 96120 RVA: 0x007371D8 File Offset: 0x007355D8
			public ResTypeInfo(string path, int count)
			{
				this.resPath = path;
				this.maxCount = count;
			}

			// Token: 0x04010DB0 RID: 69040
			public string resPath;

			// Token: 0x04010DB1 RID: 69041
			public int maxCount;
		}

		// Token: 0x0200423E RID: 16958
		public class HitData
		{
			// Token: 0x06017779 RID: 96121 RVA: 0x007371E8 File Offset: 0x007355E8
			public HitData()
			{
				this.Reset();
			}

			// Token: 0x0601777A RID: 96122 RVA: 0x007371F6 File Offset: 0x007355F6
			public void Reset()
			{
				this.go = null;
				this.canRemove = false;
				this.acc = 0;
				this.tween = null;
				this.attachGo = null;
				this.text = null;
				this.attachTween = null;
			}

			// Token: 0x0601777B RID: 96123 RVA: 0x00737229 File Offset: 0x00735629
			public void Update(int delta)
			{
				if (this.canRemove)
				{
					return;
				}
				this.acc += delta;
				if (this.acc >= ShowHitComponent.HitData.REMOVE_DURATION)
				{
					this.Remove();
				}
			}

			// Token: 0x0601777C RID: 96124 RVA: 0x0073725C File Offset: 0x0073565C
			public void Remove()
			{
				if (this.tween != null)
				{
					this.tween = null;
				}
				if (this.attachTween != null)
				{
					this.attachTween = null;
				}
				if (null != this.text)
				{
					this.text.text = string.Empty;
				}
				if (this.attachGo != null)
				{
					Singleton<CGameObjectPool>.instance.RecycleGameObject(this.attachGo);
				}
				this.attachGo = null;
				if (null != this.go)
				{
					Singleton<CGameObjectPool>.instance.RecycleGameObject(this.go);
					this.go = null;
				}
				this.canRemove = true;
			}

			// Token: 0x04010DB2 RID: 69042
			public static int REMOVE_DURATION = 1000;

			// Token: 0x04010DB3 RID: 69043
			public GameObject go;

			// Token: 0x04010DB4 RID: 69044
			public bool canRemove;

			// Token: 0x04010DB5 RID: 69045
			public Tween tween;

			// Token: 0x04010DB6 RID: 69046
			public Tween attachTween;

			// Token: 0x04010DB7 RID: 69047
			public GameObject attachGo;

			// Token: 0x04010DB8 RID: 69048
			public Text text;

			// Token: 0x04010DB9 RID: 69049
			private int acc;
		}
	}
}
