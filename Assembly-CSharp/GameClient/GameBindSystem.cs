using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000DC6 RID: 3526
	public class GameBindSystem
	{
		// Token: 0x06008EBC RID: 36540 RVA: 0x00002474 File Offset: 0x00000874
		protected void DeinitUIBinding()
		{
			this.objectBindList.RemoveAll(delegate(GameBindSystem.objectBindings obj)
			{
				obj.field.SetValue(this, null);
				return true;
			});
			this.controlBindList.RemoveAll(delegate(GameBindSystem.controlBindings obj)
			{
				if (obj.bArray)
				{
					Array array = obj.field.GetValue(this) as Array;
					for (int i = 0; i < array.Length; i++)
					{
						array.SetValue(null, i);
					}
				}
				else
				{
					obj.field.SetValue(this, null);
				}
				return true;
			});
			this.eventBindList.Clear();
			this.msgBindList.Clear();
			this.protoBindList.Clear();
			this.soundBindList.Clear();
			this.bBinding = false;
		}

		// Token: 0x06008EBD RID: 36541 RVA: 0x000024E4 File Offset: 0x000008E4
		protected void InitUIBinding()
		{
			if (this.bBinding)
			{
				return;
			}
			this.bBinding = true;
			Type type = base.GetType();
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			if (fields == null)
			{
				return;
			}
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo != null)
				{
					object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(UIObjectAttribute), false);
					if (customAttributes != null)
					{
						if (customAttributes.Length > 0)
						{
							GameBindSystem.objectBindings objectBindings = new GameBindSystem.objectBindings();
							objectBindings.name = (customAttributes[0] as UIObjectAttribute).objectName;
							objectBindings.field = fieldInfo;
							this.objectBindList.Add(objectBindings);
						}
						else
						{
							customAttributes = fieldInfo.GetCustomAttributes(typeof(UIControlAttribute), false);
							if (customAttributes != null)
							{
								if (customAttributes.Length > 0)
								{
									UIControlAttribute uicontrolAttribute = customAttributes[0] as UIControlAttribute;
									GameBindSystem.controlBindings controlBindings = new GameBindSystem.controlBindings();
									controlBindings.name = uicontrolAttribute.controlName;
									controlBindings.field = fieldInfo;
									controlBindings.type = uicontrolAttribute.componentType;
									controlBindings.bArray = fieldInfo.FieldType.IsArray;
									controlBindings.baseNum = uicontrolAttribute.baseNum;
									this.controlBindList.Add(controlBindings);
								}
							}
						}
					}
				}
			}
			MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
			for (int j = 0; j < methods.Length; j++)
			{
				MethodInfo current = methods[j];
				if (current != null)
				{
					object[] customAttributes2 = current.GetCustomAttributes(false);
					for (int k = 0; k < customAttributes2.Length; k++)
					{
						Type attributeType = customAttributes2[k].GetType();
						if (customAttributes2[k] is UIEventHandleAttribute)
						{
							UIEventHandleAttribute uieventHandleAttribute = (UIEventHandleAttribute)customAttributes2[k];
							GameBindSystem.eventBindings eventBindings = new GameBindSystem.eventBindings
							{
								controlType = uieventHandleAttribute.controlType,
								eventType = uieventHandleAttribute.eventType
							};
							if (uieventHandleAttribute.start == 0 && uieventHandleAttribute.end == 0)
							{
								eventBindings.strList.Add(uieventHandleAttribute.controlName);
								eventBindings.method = Delegate.CreateDelegate(uieventHandleAttribute.eventType, this, current, true);
							}
							else
							{
								StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
								for (int l = uieventHandleAttribute.start; l <= uieventHandleAttribute.end; l++)
								{
									MyExtensionMethods.Clear(stringBuilder);
									stringBuilder.AppendFormat(uieventHandleAttribute.controlName, l);
									eventBindings.strList.Add(stringBuilder.ToString());
								}
								StringBuilderCache.Release(stringBuilder);
								eventBindings.method = Delegate.CreateDelegate(uieventHandleAttribute.eventType, this, current, true);
							}
							this.eventBindList.Add(eventBindings);
						}
						else if (customAttributes2[k] is MessageHandleAttribute)
						{
							GameBindSystem.msgBindings msgBindings = new GameBindSystem.msgBindings();
							msgBindings.id = ((MessageHandleAttribute)customAttributes2[k]).id;
							try
							{
								msgBindings.method = Delegate.CreateDelegate(typeof(Action<MsgDATA>), this, current, true);
							}
							catch (Exception ex)
							{
								Logger.LogErrorFormat("Error!! Bind Message Method {0} to Contorl {1}: {2} \n", new object[]
								{
									current.ToString(),
									msgBindings.id,
									ex.ToString()
								});
							}
							this.msgBindList.Add(msgBindings);
						}
						else if (customAttributes2[k] is ProtocolHandleAttribute)
						{
							ProtocolHandleAttribute eventAttr = (ProtocolHandleAttribute)customAttributes2[k];
							IGetMsgID getMsgID = eventAttr.GetBinder() as IGetMsgID;
							if (getMsgID == null)
							{
								Logger.LogError(string.Format("Type{0} in class {1} do not implement Protocol.IGetMsgID", attributeType.Name, type.Name));
							}
							else
							{
								GameBindSystem.protoBindings protoBindings = new GameBindSystem.protoBindings();
								protoBindings.id = getMsgID.GetMsgID();
								protoBindings.action = delegate(MsgDATA data)
								{
									object binder = eventAttr.GetBinder();
									int num = 0;
									if (!(binder is IProtocolStream))
									{
										Logger.LogError(string.Format("Type{0} in class {1} do not implement Protocol.IProtocolStream", attributeType.Name, type.Name));
										return;
									}
									((IProtocolStream)binder).decode(data.bytes, ref num);
									object[] parameters = new object[]
									{
										binder
									};
									current.Invoke(this, parameters);
								};
								this.protoBindList.Add(protoBindings);
							}
						}
					}
				}
			}
		}

		// Token: 0x06008EBE RID: 36542 RVA: 0x0000295C File Offset: 0x00000D5C
		protected void ShowBindInfo()
		{
			Singleton<ExceptionManager>.GetInstance().RecordLog("file name:" + base.GetType().Name + "\n");
			if (this.objectBindList.Count > 0)
			{
				Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("objectBindings:{0}\n", this.objectBindList.Count));
				for (int i = 0; i < this.objectBindList.Count; i++)
				{
					Logger.LogErrorFormat("name:{0}\n", new object[]
					{
						this.objectBindList[i].name
					});
				}
			}
			if (this.controlBindList.Count > 0)
			{
				Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("controlBindList:{0}\n", this.controlBindList.Count));
				for (int j = 0; j < this.controlBindList.Count; j++)
				{
					Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("name:{0}\n", this.controlBindList[j].name));
				}
			}
			if (this.eventBindList.Count > 0)
			{
				Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("eventBindList:{0}\n", this.eventBindList.Count));
				for (int k = 0; k < this.eventBindList.Count; k++)
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int l = 0; l < this.eventBindList[k].strList.Count; l++)
					{
						stringBuilder.AppendFormat(",{0}", k, this.eventBindList[k].strList[l]);
					}
					Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("name:{0}", stringBuilder.ToString()));
				}
			}
			if (this.msgBindList.Count > 0)
			{
				Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("msgBindList:{0}\n", this.msgBindList.Count));
				for (int m = 0; m < this.msgBindList.Count; m++)
				{
					Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("id:{0}\n", this.msgBindList[m].id));
				}
			}
			if (this.protoBindList.Count > 0)
			{
				Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("protoBindList:{0}\n", this.protoBindList.Count));
				for (int n = 0; n < this.protoBindList.Count; n++)
				{
					Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("id:{0}\n", this.protoBindList[n].id));
				}
			}
			if (this.soundBindList.Count > 0)
			{
				Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("soundBindings:{0}\n", this.soundBindList.Count));
				for (int num = 0; num < this.soundBindList.Count; num++)
				{
					Singleton<ExceptionManager>.GetInstance().RecordLog(string.Format("name:{0}\n", this.soundBindList[num].name));
				}
			}
			Singleton<ExceptionManager>.GetInstance().PrintLogToFile(true);
		}

		// Token: 0x06008EBF RID: 36543 RVA: 0x00002CC4 File Offset: 0x000010C4
		protected void InitUISystem(GameObject frame)
		{
			if (frame == null)
			{
				return;
			}
			this.mRoot = frame;
			for (int i = 0; i < this.objectBindList.Count; i++)
			{
				GameBindSystem.objectBindings objectBindings = this.objectBindList[i];
				GameObject value4 = Utility.FindGameObject(frame, objectBindings.name, true);
				objectBindings.field.SetValue(this, value4);
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			for (int j = 0; j < this.controlBindList.Count; j++)
			{
				GameBindSystem.controlBindings controlBindings = this.controlBindList[j];
				Type type = controlBindings.type;
				if (type == null)
				{
					type = controlBindings.field.FieldType;
				}
				if (controlBindings.bArray)
				{
					Array array = controlBindings.field.GetValue(this) as Array;
					for (int k = 0; k < array.Length; k++)
					{
						MyExtensionMethods.Clear(stringBuilder);
						stringBuilder.AppendFormat(controlBindings.name, k + controlBindings.baseNum);
						string path = stringBuilder.ToString();
						Component value2 = Utility.FindComponent(frame, type, path, true);
						array.SetValue(value2, k);
					}
				}
				else
				{
					Component value3 = Utility.FindComponent(frame, type, controlBindings.name, true);
					controlBindings.field.SetValue(this, value3);
				}
			}
			StringBuilderCache.Release(stringBuilder);
			for (int l = 0; l < this.eventBindList.Count; l++)
			{
				GameBindSystem.eventBindings eventBindings = this.eventBindList[l];
				for (int m = 0; m < eventBindings.strList.Count; m++)
				{
					string text = eventBindings.strList[m];
					object obj = Utility.FindComponent(frame, eventBindings.controlType, text, true);
					if (eventBindings.controlType == typeof(Button))
					{
						Button button = obj as Button;
						if (button)
						{
							try
							{
								if (eventBindings.strList.Count <= 1)
								{
									UnityAction unityAction = eventBindings.method as UnityAction;
									GameBindSystem.soundBindings soundBindings = null;
									for (int n = 0; n < this.soundBindList.Count; n++)
									{
										if (text == this.soundBindList[n].name)
										{
											soundBindings = this.soundBindList[n];
											break;
										}
									}
									UIFrameSound uiframeSound;
									if (soundBindings == null)
									{
										uiframeSound = new UIFrameSound(text, "Sound/SE/click1");
									}
									else
									{
										uiframeSound = new UIFrameSound(text, "Sound/SE/click1");
										uiframeSound.bNeed = soundBindings.bNeed;
										uiframeSound.sound = soundBindings.sound;
									}
									if (uiframeSound != null)
									{
										button.onClick.AddListener(new UnityAction(uiframeSound.OnPlaySound));
									}
									button.onClick.AddListener(unityAction);
								}
								else
								{
									UnityAction<int> callback = eventBindings.method as UnityAction<int>;
									int index = m;
									button.onClick.AddListener(delegate()
									{
										callback.DynamicInvoke(new object[]
										{
											index
										});
									});
								}
							}
							catch (Exception ex)
							{
								Logger.LogErrorFormat("Error!! Bind Method {0} to Contorl {1}: {2} \n", new object[]
								{
									eventBindings.method.ToString(),
									text,
									ex.ToString()
								});
							}
						}
						else
						{
							Logger.LogErrorFormat("Current Can Only Bind Button Method {0} to Contorl {1} \n", new object[]
							{
								eventBindings.method.ToString(),
								text
							});
						}
					}
					else if (eventBindings.controlType == typeof(Toggle))
					{
						if (eventBindings.strList.Count <= 1)
						{
							Toggle toggle = obj as Toggle;
							toggle.onValueChanged.AddListener(eventBindings.method as UnityAction<bool>);
						}
						else
						{
							Toggle toggle2 = obj as Toggle;
							int iIndex = m;
							Delegate callback = eventBindings.method;
							toggle2.onValueChanged.AddListener(delegate(bool value)
							{
								callback.DynamicInvoke(new object[]
								{
									iIndex,
									value
								});
							});
						}
					}
				}
			}
		}

		// Token: 0x06008EC0 RID: 36544 RVA: 0x00003108 File Offset: 0x00001508
		protected void RegisterMsgHandler()
		{
			for (int i = 0; i < this.msgBindList.Count; i++)
			{
				NetProcess.AddMsgHandler(this.msgBindList[i].id, this.msgBindList[i].method as Action<MsgDATA>);
			}
			for (int j = 0; j < this.protoBindList.Count; j++)
			{
				NetProcess.AddMsgHandler(this.protoBindList[j].id, this.protoBindList[j].action);
			}
		}

		// Token: 0x06008EC1 RID: 36545 RVA: 0x000031A0 File Offset: 0x000015A0
		protected void RemoveMsgHandler()
		{
			for (int i = 0; i < this.msgBindList.Count; i++)
			{
				NetProcess.RemoveMsgHandler(this.msgBindList[i].id, this.msgBindList[i].method as Action<MsgDATA>);
			}
			for (int j = 0; j < this.protoBindList.Count; j++)
			{
				NetProcess.RemoveMsgHandler(this.protoBindList[j].id, this.protoBindList[j].action);
			}
		}

		// Token: 0x06008EC2 RID: 36546 RVA: 0x00003238 File Offset: 0x00001638
		public void InitBindSystem(GameObject frameroot)
		{
			try
			{
				this.InitUIBinding();
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.Message);
			}
			this.InitUISystem(frameroot);
			this.RegisterMsgHandler();
		}

		// Token: 0x06008EC3 RID: 36547 RVA: 0x00003280 File Offset: 0x00001680
		public T GetComponentInChilderByName<T>(string name) where T : Component
		{
			if (this.mRoot == null)
			{
				Logger.LogError("mRoot is nil");
				return (T)((object)null);
			}
			if ("." == name)
			{
				return this.mRoot.GetComponentInChildren<T>();
			}
			T componetInChild = Utility.GetComponetInChild<T>(this.mRoot, name);
			if (componetInChild != null)
			{
				return componetInChild;
			}
			return (T)((object)null);
		}

		// Token: 0x06008EC4 RID: 36548 RVA: 0x000032F4 File Offset: 0x000016F4
		public T GetComponentByName<T>(string name) where T : Component
		{
			if (this.mRoot == null)
			{
				Logger.LogError("mRoot is nil");
				return (T)((object)null);
			}
			if ("." == name)
			{
				return this.mRoot.GetComponent<T>();
			}
			T t = Utility.FindComponent<T>(this.mRoot, name, true);
			if (t != null)
			{
				return t;
			}
			return (T)((object)null);
		}

		// Token: 0x06008EC5 RID: 36549 RVA: 0x00003366 File Offset: 0x00001766
		public void ExistBindSystem()
		{
			this.mRoot = null;
			this.RemoveMsgHandler();
			this.DeinitUIBinding();
		}

		// Token: 0x040046C1 RID: 18113
		private GameObject mRoot;

		// Token: 0x040046C2 RID: 18114
		protected List<GameBindSystem.objectBindings> objectBindList = new List<GameBindSystem.objectBindings>();

		// Token: 0x040046C3 RID: 18115
		protected List<GameBindSystem.controlBindings> controlBindList = new List<GameBindSystem.controlBindings>();

		// Token: 0x040046C4 RID: 18116
		protected List<GameBindSystem.eventBindings> eventBindList = new List<GameBindSystem.eventBindings>();

		// Token: 0x040046C5 RID: 18117
		protected List<GameBindSystem.msgBindings> msgBindList = new List<GameBindSystem.msgBindings>();

		// Token: 0x040046C6 RID: 18118
		protected List<GameBindSystem.protoBindings> protoBindList = new List<GameBindSystem.protoBindings>();

		// Token: 0x040046C7 RID: 18119
		protected List<GameBindSystem.soundBindings> soundBindList = new List<GameBindSystem.soundBindings>();

		// Token: 0x040046C8 RID: 18120
		protected bool bBinding;

		// Token: 0x02000DC7 RID: 3527
		public class objectBindings
		{
			// Token: 0x040046C9 RID: 18121
			public string name;

			// Token: 0x040046CA RID: 18122
			public FieldInfo field;
		}

		// Token: 0x02000DC8 RID: 3528
		public class controlBindings
		{
			// Token: 0x040046CB RID: 18123
			public string name;

			// Token: 0x040046CC RID: 18124
			public FieldInfo field;

			// Token: 0x040046CD RID: 18125
			public Type type;

			// Token: 0x040046CE RID: 18126
			public bool bArray;

			// Token: 0x040046CF RID: 18127
			public int baseNum;
		}

		// Token: 0x02000DC9 RID: 3529
		public class eventBindings
		{
			// Token: 0x040046D0 RID: 18128
			public List<string> strList = new List<string>();

			// Token: 0x040046D1 RID: 18129
			public Type controlType;

			// Token: 0x040046D2 RID: 18130
			public Type eventType;

			// Token: 0x040046D3 RID: 18131
			public Delegate method;
		}

		// Token: 0x02000DCA RID: 3530
		public class msgBindings
		{
			// Token: 0x040046D4 RID: 18132
			public uint id;

			// Token: 0x040046D5 RID: 18133
			public Delegate method;
		}

		// Token: 0x02000DCB RID: 3531
		public class protoBindings
		{
			// Token: 0x040046D6 RID: 18134
			public uint id;

			// Token: 0x040046D7 RID: 18135
			public Action<MsgDATA> action;
		}

		// Token: 0x02000DCC RID: 3532
		public class soundBindings
		{
			// Token: 0x040046D8 RID: 18136
			public string name;

			// Token: 0x040046D9 RID: 18137
			public bool bNeed;

			// Token: 0x040046DA RID: 18138
			public string sound;
		}
	}
}
