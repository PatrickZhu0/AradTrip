using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001376 RID: 4982
	public class ActiveObject : CachedObject
	{
		// Token: 0x17001BB1 RID: 7089
		// (get) Token: 0x0600C13D RID: 49469 RVA: 0x002E0090 File Offset: 0x002DE490
		public GameObject gameObject
		{
			get
			{
				return this.goLocal;
			}
		}

		// Token: 0x0600C13E RID: 49470 RVA: 0x002E0098 File Offset: 0x002DE498
		private void _InitVarBinder()
		{
			this.m_kActiveBindRecords = this.goLocal.GetComponent<ActiveBindRecords>();
		}

		// Token: 0x0600C13F RID: 49471 RVA: 0x002E00AC File Offset: 0x002DE4AC
		private void _InitMainDesc()
		{
			if (!string.IsNullOrEmpty(this.activeData.mainItem.MainInitDesc))
			{
				string[] array = this.activeData.mainItem.MainInitDesc.Split(new char[]
				{
					'\r',
					'\n'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						Match match = ActiveObject.s_regex_maininit.Match(array[i]);
						if (!string.IsNullOrEmpty(match.Groups[0].Value))
						{
							string value = match.Groups[2].Value;
							if (value != null)
							{
								if (!(value == "Text"))
								{
									if (value == "Image")
									{
										Image image = Utility.FindComponent<Image>(this.goLocal, match.Groups[1].Value, true);
										if (image != null)
										{
											ETCImageLoader.LoadSprite(ref image, match.Groups[3].Value, true);
											image.SetNativeSize();
										}
									}
								}
								else
								{
									Text text = Utility.FindComponent<Text>(this.goLocal, match.Groups[1].Value, true);
									if (text != null)
									{
										text.text = match.Groups[3].Value;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C140 RID: 49472 RVA: 0x002E021B File Offset: 0x002DE61B
		public static void Clear()
		{
			if (ActiveObject.ms_kStringBuilder != null)
			{
				StringBuilderCache.Release(ActiveObject.ms_kStringBuilder);
				ActiveObject.ms_kStringBuilder = null;
			}
		}

		// Token: 0x0600C141 RID: 49473 RVA: 0x002E0238 File Offset: 0x002DE638
		private void _InitRedPoint()
		{
			this.m_akGoRedPoints = RedPointObject.Create(this.activeData.mainItem.RedPointLocalPath, this.goLocal);
			if (this.m_akGoRedPoints != null)
			{
				for (int i = 0; i < this.m_akGoRedPoints.Count; i++)
				{
					this.m_akGoRedPoints[i].Current.CustomActive(false);
				}
				for (int j = 0; j < this.m_akGoRedPoints.Count; j++)
				{
					if (this.m_akGoRedPoints[j].redBinder != null)
					{
						this.m_akGoRedPoints[j].redBinder.iMainId = this.activeData.iActiveID;
					}
				}
			}
		}

		// Token: 0x0600C142 RID: 49474 RVA: 0x002E0300 File Offset: 0x002DE700
		private void _UpdateRedPoint()
		{
			if (this.m_akGoRedPoints != null)
			{
				for (int i = 0; i < this.m_akGoRedPoints.Count; i++)
				{
					bool bActive = DataManager<ActiveManager>.GetInstance().CheckHasFinishedChildItem(this.activeData, this.m_akGoRedPoints[i].Keys);
					this.m_akGoRedPoints[i].Current.CustomActive(bActive);
				}
			}
		}

		// Token: 0x0600C143 RID: 49475 RVA: 0x002E0370 File Offset: 0x002DE770
		public override void OnCreate(object[] param)
		{
			this.goLocal = (param[0] as GameObject);
			this.goPrefab = (param[1] as GameObject);
			this.activeData = (param[2] as ActiveManager.ActiveData);
			this.goParent = ((!(this.goLocal == null)) ? this.goLocal.transform.parent.gameObject : this.goPrefab.transform.parent.gameObject);
			if (this.goLocal == null)
			{
				this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
				Utility.AttachTo(this.goLocal, this.goParent, false);
			}
			this._InitMainDesc();
			this._InitVarBinder();
			this._InitRedPoint();
			this.m_akValues.Clear();
			if (ActiveObject.ms_kStringBuilder == null)
			{
				ActiveObject.ms_kStringBuilder = StringBuilderCache.Acquire(256);
			}
			this.Enable();
			this._UpdateItem();
		}

		// Token: 0x0600C144 RID: 49476 RVA: 0x002E0463 File Offset: 0x002DE863
		public override void OnRecycle()
		{
			this.Disable();
		}

		// Token: 0x0600C145 RID: 49477 RVA: 0x002E046B File Offset: 0x002DE86B
		public override void Enable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(true);
			}
		}

		// Token: 0x0600C146 RID: 49478 RVA: 0x002E048A File Offset: 0x002DE88A
		public override void Disable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(false);
			}
		}

		// Token: 0x0600C147 RID: 49479 RVA: 0x002E04A9 File Offset: 0x002DE8A9
		public override void OnDecycle(object[] param)
		{
			this.OnCreate(param);
		}

		// Token: 0x0600C148 RID: 49480 RVA: 0x002E04B2 File Offset: 0x002DE8B2
		public override void OnRefresh(object[] param)
		{
			this._UpdateItem();
		}

		// Token: 0x0600C149 RID: 49481 RVA: 0x002E04BA File Offset: 0x002DE8BA
		public override bool NeedFilter(object[] param)
		{
			return this.activeData.iActiveID != (int)param[0];
		}

		// Token: 0x0600C14A RID: 49482 RVA: 0x002E04D4 File Offset: 0x002DE8D4
		private void _UpdateMainKeyValues()
		{
			if (this.goLocal != null && !string.IsNullOrEmpty(this.activeData.mainItem.ParticularDesc))
			{
				string[] array = this.activeData.mainItem.ParticularDesc.Split(new char[]
				{
					'\r',
					'\n'
				});
				int num = -1;
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						Match match = ActiveObject.s_regex.Match(array[i]);
						if (match != null)
						{
							ActiveObject.ValueObject valueObject = new ActiveObject.ValueObject();
							num = (valueObject.iIndex = num + 1);
							string value = match.Groups[1].Value;
							string value2 = match.Groups[2].Value;
							string value3 = match.Groups[3].Value;
							int num2 = 0;
							MyExtensionMethods.Clear(ActiveObject.ms_kStringBuilder);
							IEnumerator enumerator = ActiveObject.s_regex_content.Matches(value3).GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									object obj = enumerator.Current;
									Match match2 = (Match)obj;
									ActiveObject.ms_kStringBuilder.Append(value3.Substring(num2, match2.Index - num2));
									bool flag = false;
									for (int j = 0; j < this.activeData.mainKeyValue.Count; j++)
									{
										if (this.activeData.mainKeyValue[j].key == match2.Groups[1].Value)
										{
											ActiveObject.ms_kStringBuilder.Append(this.activeData.mainKeyValue[j].value);
											flag = true;
											break;
										}
									}
									if (!flag)
									{
										CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo(this.activeData.mainItem.ID + "_" + match2.Groups[1].Value);
										if (countInfo != null)
										{
											flag = true;
											ActiveObject.ms_kStringBuilder.Append(countInfo.value);
										}
									}
									if (!flag)
									{
										ActiveObject.ms_kStringBuilder.Append(match2.Groups[2].Value);
									}
									num2 = match2.Index + match2.Length;
								}
							}
							finally
							{
								IDisposable disposable;
								if ((disposable = (enumerator as IDisposable)) != null)
								{
									disposable.Dispose();
								}
							}
							ActiveObject.ms_kStringBuilder.Append(value3.Substring(num2, value3.Length - num2));
							string text = ActiveObject.ms_kStringBuilder.ToString();
							if (value2 == "Text")
							{
								Text text2 = Utility.FindComponent<Text>(this.goLocal, value, true);
								if (text2 != null)
								{
									text2.text = text;
									valueObject.kObject = text2;
									valueObject.kOrgValue = value3;
								}
							}
							else if (value2 == "Image")
							{
								Image image = Utility.FindComponent<Image>(this.goLocal, value, true);
								if (image != null)
								{
									ETCImageLoader.LoadSprite(ref image, text, true);
									valueObject.kObject = image;
								}
							}
							else if (value2 == "Button")
							{
								Button button = Utility.FindComponent<Button>(this.goLocal, value, true);
								if (button != null)
								{
									OnClickActive script = Utility.FindComponent<OnClickActive>(this.goLocal, value, true);
									button.onClick.RemoveAllListeners();
									button.onClick.AddListener(delegate()
									{
										if (script.m_eOnClickCloseType == OnClickActive.OnClickCloseType.OCCT_PRE)
										{
											ClientFrameBinder componentInParent = script.GetComponentInParent<ClientFrameBinder>();
											if (null != componentInParent)
											{
												componentInParent.CloseFrame(true);
											}
										}
										DataManager<ActiveManager>.GetInstance().OnClickActivity(this.activeData, script, null);
										if (script.m_eOnClickCloseType == OnClickActive.OnClickCloseType.OCCT_AFT)
										{
											ClientFrameBinder componentInParent2 = script.GetComponentInParent<ClientFrameBinder>();
											if (null != componentInParent2)
											{
												componentInParent2.CloseFrame(true);
											}
										}
									});
									valueObject.kObject = button;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C14B RID: 49483 RVA: 0x002E08A4 File Offset: 0x002DECA4
		private void _UpdateItem()
		{
			this._UpdateMainKeyValues();
			this._UpdateVarBinder();
			this._UpdateRedPoint();
		}

		// Token: 0x0600C14C RID: 49484 RVA: 0x002E08B8 File Offset: 0x002DECB8
		private void _UpdateVarBinder()
		{
			if (this.m_kActiveBindRecords != null)
			{
				for (int i = 0; i < this.m_kActiveBindRecords.m_VarBinders.Count; i++)
				{
					this.m_kActiveBindRecords.m_VarBinders[i].RefreshStatus();
				}
			}
		}

		// Token: 0x04006D54 RID: 27988
		protected GameObject goLocal;

		// Token: 0x04006D55 RID: 27989
		protected GameObject goParent;

		// Token: 0x04006D56 RID: 27990
		protected GameObject goPrefab;

		// Token: 0x04006D57 RID: 27991
		private ActiveBindRecords m_kActiveBindRecords;

		// Token: 0x04006D58 RID: 27992
		private ActiveManager.ActiveData activeData;

		// Token: 0x04006D59 RID: 27993
		private static Regex s_regex = new Regex("<path=(.+) type=(.+) content=(.+)>");

		// Token: 0x04006D5A RID: 27994
		private static Regex s_regex_content = new Regex("<key=(\\w+) default=(\\w*)>");

		// Token: 0x04006D5B RID: 27995
		private static StringBuilder ms_kStringBuilder;

		// Token: 0x04006D5C RID: 27996
		public static Regex s_regex_maininit = new Regex("<Name=(.+) Type=(\\w+) Value=(.+)>", RegexOptions.Singleline);

		// Token: 0x04006D5D RID: 27997
		private List<ActiveObject.ValueObject> m_akValues = new List<ActiveObject.ValueObject>();

		// Token: 0x04006D5E RID: 27998
		private LevelFullControl comLevelFullControl;

		// Token: 0x04006D5F RID: 27999
		private List<RedPointObject> m_akGoRedPoints;

		// Token: 0x02001377 RID: 4983
		private class ValueObject
		{
			// Token: 0x04006D60 RID: 28000
			public int iIndex;

			// Token: 0x04006D61 RID: 28001
			public string kOrgValue;

			// Token: 0x04006D62 RID: 28002
			public string kDefault;

			// Token: 0x04006D63 RID: 28003
			public object kObject;

			// Token: 0x04006D64 RID: 28004
			public bool bNeedMatch;
		}
	}
}
