using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x020045D1 RID: 17873
internal class InvokeMethod
{
	// Token: 0x060191DE RID: 102878 RVA: 0x007EF03B File Offset: 0x007ED43B
	public static void Enter()
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().Enter();
	}

	// Token: 0x060191DF RID: 102879 RVA: 0x007EF047 File Offset: 0x007ED447
	public static void Exit()
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().Exit();
	}

	// Token: 0x060191E0 RID: 102880 RVA: 0x007EF053 File Offset: 0x007ED453
	public static void Update()
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().Update();
	}

	// Token: 0x060191E1 RID: 102881 RVA: 0x007EF05F File Offset: 0x007ED45F
	public static void Invoke(float fDelyTime, UnityAction callback)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().InvokeCall(Time.time, fDelyTime, callback);
	}

	// Token: 0x060191E2 RID: 102882 RVA: 0x007EF074 File Offset: 0x007ED474
	public static void InvokeInterval(object target, float fDelayTime, float fIntervalTime, float fLastTime, UnityAction onBegin, UnityAction onUpdate, UnityAction onEnd)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().InvokeIntervalCall(target, Time.time, fDelayTime, fIntervalTime, fLastTime, onBegin, onUpdate, onEnd);
	}

	// Token: 0x060191E3 RID: 102883 RVA: 0x007EF09B File Offset: 0x007ED49B
	public static void RmoveInvokeIntervalCall(object target)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeIntervalCall(target);
	}

	// Token: 0x060191E4 RID: 102884 RVA: 0x007EF0A8 File Offset: 0x007ED4A8
	public static void RmoveInvokeIntervalCall(int unique_id)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeIntervalCall(unique_id);
	}

	// Token: 0x060191E5 RID: 102885 RVA: 0x007EF0B5 File Offset: 0x007ED4B5
	public static void Invoke(object target, float fDelyTime, UnityAction callback)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().InvokeCall(target, Time.time, fDelyTime, callback);
	}

	// Token: 0x060191E6 RID: 102886 RVA: 0x007EF0C9 File Offset: 0x007ED4C9
	public static void RemoveInvokeCall(object target)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeCall(target);
	}

	// Token: 0x060191E7 RID: 102887 RVA: 0x007EF0D6 File Offset: 0x007ED4D6
	public static void RemoveInvokeCall(UnityAction callback)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().RmoveInvokeCall(callback);
	}

	// Token: 0x060191E8 RID: 102888 RVA: 0x007EF0E3 File Offset: 0x007ED4E3
	public static void AddUniqueInvoke(InvokeMethod.TaskManager.Invoke invoke)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().AddUniqueInvoke(ref invoke);
	}

	// Token: 0x060191E9 RID: 102889 RVA: 0x007EF0F1 File Offset: 0x007ED4F1
	public static void RemoveUniqueInvoke(InvokeMethod.TaskManager.Invoke invoke)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().RemoveUniqueInvoke(ref invoke);
	}

	// Token: 0x060191EA RID: 102890 RVA: 0x007EF0FF File Offset: 0x007ED4FF
	public static void AddPerFrameCall(IClientFrame clientFrame, UnityAction callback)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().AddPerFrameCall(clientFrame, callback);
	}

	// Token: 0x060191EB RID: 102891 RVA: 0x007EF10D File Offset: 0x007ED50D
	public static void RemovePerFrameCall(IClientFrame clientFrame)
	{
		Singleton<InvokeMethod.TaskManager>.GetInstance().RemovePerFrameCall(clientFrame);
	}

	// Token: 0x020045D2 RID: 17874
	public class TaskManager : Singleton<InvokeMethod.TaskManager>
	{
		// Token: 0x060191ED RID: 102893 RVA: 0x007EF14E File Offset: 0x007ED54E
		public void Enter()
		{
			if (this.bUpdate)
			{
				Logger.LogError("Enter when update ?");
			}
			MonoSingleton<GameFrameWork>.instance.onLastUpdate.AddListener(new UnityAction(this.OnLastUpdate));
		}

		// Token: 0x060191EE RID: 102894 RVA: 0x007EF180 File Offset: 0x007ED580
		public void Exit()
		{
			this.akInvokeLists.Clear();
			this.akInvokeNeedDelete.Clear();
			MonoSingleton<GameFrameWork>.instance.onLastUpdate.RemoveListener(new UnityAction(this.OnLastUpdate));
			this.onGuiPerframeCall.Clear();
		}

		// Token: 0x060191EF RID: 102895 RVA: 0x007EF1BE File Offset: 0x007ED5BE
		public void InvokeCall(float fStart, float fDelyTime, UnityAction callback)
		{
			this.akInvokeLists.Add(new InvokeMethod.TaskManager.Invoke(fStart, fDelyTime, callback, null));
		}

		// Token: 0x060191F0 RID: 102896 RVA: 0x007EF1D4 File Offset: 0x007ED5D4
		public int InvokeIntervalCall(object target, float fStart, float fDelayTime, float fInterval, float fLastTime, UnityAction onBegin, UnityAction onInterval, UnityAction onEnd)
		{
			InvokeMethod.TaskManager.IntervalInvoke intervalInvoke = new InvokeMethod.TaskManager.IntervalInvoke
			{
				unique_id = ++InvokeMethod.TaskManager.IntervalInvoke.ms_unique_id,
				fStart = fStart,
				fDelay = fDelayTime,
				fIntervalTime = fInterval,
				fLastTime = fLastTime,
				onBegin = onBegin,
				onInterval = onInterval,
				onEnd = onEnd,
				target = target
			};
			this.akIntervalInvokeLists.Add(intervalInvoke);
			return intervalInvoke.unique_id;
		}

		// Token: 0x060191F1 RID: 102897 RVA: 0x007EF24C File Offset: 0x007ED64C
		public void RmoveInvokeIntervalCall(object target)
		{
			for (int i = 0; i < this.akIntervalInvokeLists.Count; i++)
			{
				if (this.akIntervalInvokeLists[i].target == target)
				{
					this.akIntervalInvokeLists[i].NeedRemove = true;
				}
			}
		}

		// Token: 0x060191F2 RID: 102898 RVA: 0x007EF2A0 File Offset: 0x007ED6A0
		public void RmoveInvokeIntervalCall(int unique_id)
		{
			for (int i = 0; i < this.akIntervalInvokeLists.Count; i++)
			{
				if (this.akIntervalInvokeLists[i].unique_id == unique_id)
				{
					this.akIntervalInvokeLists[i].NeedRemove = true;
					break;
				}
			}
		}

		// Token: 0x060191F3 RID: 102899 RVA: 0x007EF2F7 File Offset: 0x007ED6F7
		public void InvokeCall(object target, float fStart, float fDelyTime, UnityAction callback)
		{
			this.akInvokeLists.Add(new InvokeMethod.TaskManager.Invoke(fStart, fDelyTime, callback, target));
		}

		// Token: 0x060191F4 RID: 102900 RVA: 0x007EF310 File Offset: 0x007ED710
		public void RmoveInvokeCall(object target)
		{
			for (int i = 0; i < this.akInvokeLists.Count; i++)
			{
				if (this.akInvokeLists[i].target == target)
				{
					this.akInvokeLists[i].SetNeedRemove(true);
				}
			}
		}

		// Token: 0x060191F5 RID: 102901 RVA: 0x007EF364 File Offset: 0x007ED764
		public void RmoveInvokeCall(UnityAction callback)
		{
			for (int i = 0; i < this.akInvokeLists.Count; i++)
			{
				if (this.akInvokeLists[i].callback == callback)
				{
					this.akInvokeLists[i].SetNeedRemove(true);
				}
			}
		}

		// Token: 0x060191F6 RID: 102902 RVA: 0x007EF3BC File Offset: 0x007ED7BC
		public void AddUniqueInvoke(ref InvokeMethod.TaskManager.Invoke invoke)
		{
			bool flag = false;
			for (int i = 0; i < this.akInvokeNeedDelete.Count; i++)
			{
				if (this.akInvokeNeedDelete[i] == invoke)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				this.akInvokeNeedDelete.Add(invoke);
			}
		}

		// Token: 0x060191F7 RID: 102903 RVA: 0x007EF40F File Offset: 0x007ED80F
		public void RemoveUniqueInvoke(ref InvokeMethod.TaskManager.Invoke invoke)
		{
			this.akInvokeNeedDelete.Remove(invoke);
		}

		// Token: 0x060191F8 RID: 102904 RVA: 0x007EF420 File Offset: 0x007ED820
		public void AddPerFrameCall(IClientFrame clientFrame, UnityAction callback)
		{
			for (int i = 0; i < this.onGuiPerframeCall.Count; i++)
			{
				if (this.onGuiPerframeCall[i].Key == clientFrame)
				{
					this.onGuiPerframeCall[i].Value.Add(callback);
					return;
				}
			}
			List<UnityAction> list = new List<UnityAction>();
			list.Add(callback);
			this.onGuiPerframeCall.Add(new KeyValuePair<IClientFrame, List<UnityAction>>(clientFrame, list));
		}

		// Token: 0x060191F9 RID: 102905 RVA: 0x007EF4A0 File Offset: 0x007ED8A0
		public void RemovePerFrameCall(IClientFrame clientFrame)
		{
			for (int i = 0; i < this.onGuiPerframeCall.Count; i++)
			{
				if (this.onGuiPerframeCall[i].Key == clientFrame)
				{
					this.onGuiPerframeCall.RemoveAt(i);
					return;
				}
			}
		}

		// Token: 0x060191FA RID: 102906 RVA: 0x007EF4F0 File Offset: 0x007ED8F0
		public void Update()
		{
			this.bUpdate = true;
			for (int i = 0; i < this.akInvokeLists.Count; i++)
			{
				if (this.akInvokeLists[i] != null && this.akInvokeLists[i].IsStart() && !this.akInvokeLists[i].NeedRemove())
				{
					this.akInvokeLists[i].DoInvoke();
					this.akInvokeLists[i].SetNeedRemove(true);
				}
			}
			for (int j = 0; j < this.akInvokeLists.Count; j++)
			{
				if (this.akInvokeLists[j] == null || this.akInvokeLists[j].NeedRemove())
				{
					this.akInvokeLists.RemoveAt(j--);
				}
			}
			for (int k = 0; k < this.akInvokeNeedDelete.Count; k++)
			{
				InvokeMethod.TaskManager.Invoke invoke = this.akInvokeNeedDelete[k];
				if (invoke.IsStart())
				{
					this.akInvokeNeedDelete.RemoveAt(k--);
					invoke.DoInvoke();
				}
			}
			this.UpdateIntervalInvoke();
			this.bUpdate = false;
		}

		// Token: 0x060191FB RID: 102907 RVA: 0x007EF62C File Offset: 0x007EDA2C
		private void UpdateIntervalInvoke()
		{
			for (int i = 0; i < this.akIntervalInvokeLists.Count; i++)
			{
				if (this.akIntervalInvokeLists[i] != null)
				{
					if (!this.akIntervalInvokeLists[i].NeedRemove)
					{
						if (this.akIntervalInvokeLists[i].IsStart())
						{
							if (!this.akIntervalInvokeLists[i].bHasBegin)
							{
								this.akIntervalInvokeLists[i].bHasBegin = true;
								if (this.akIntervalInvokeLists[i].onBegin != null)
								{
									this.akIntervalInvokeLists[i].onBegin.Invoke();
								}
							}
							else
							{
								if (this.akIntervalInvokeLists[i].CanInterval() && this.akIntervalInvokeLists[i].onInterval != null)
								{
									this.akIntervalInvokeLists[i].onInterval.Invoke();
									this.akIntervalInvokeLists[i].iInvokeTimes++;
								}
								if (this.akIntervalInvokeLists[i].IsEnd())
								{
									if (this.akIntervalInvokeLists[i].onEnd != null)
									{
										this.akIntervalInvokeLists[i].onEnd.Invoke();
									}
									this.akIntervalInvokeLists[i].NeedRemove = true;
								}
							}
						}
					}
				}
			}
			for (int j = 0; j < this.akIntervalInvokeLists.Count; j++)
			{
				if (this.akIntervalInvokeLists[j] == null || this.akIntervalInvokeLists[j].NeedRemove)
				{
					this.akIntervalInvokeLists.RemoveAt(j--);
				}
			}
		}

		// Token: 0x060191FC RID: 102908 RVA: 0x007EF7F4 File Offset: 0x007EDBF4
		public void OnLastUpdate()
		{
			while (this.onGuiPerframeCall.Count > 0)
			{
				List<UnityAction> value = this.onGuiPerframeCall[0].Value;
				if (value.Count > 0)
				{
					UnityAction unityAction = value[0];
					value.RemoveAt(0);
					if (unityAction != null)
					{
						unityAction.Invoke();
					}
				}
				if (value.Count == 0)
				{
					this.onGuiPerframeCall.RemoveAt(0);
				}
			}
		}

		// Token: 0x0401200B RID: 73739
		private List<InvokeMethod.TaskManager.IntervalInvoke> akIntervalInvokeLists = new List<InvokeMethod.TaskManager.IntervalInvoke>();

		// Token: 0x0401200C RID: 73740
		private List<InvokeMethod.TaskManager.Invoke> akInvokeLists = new List<InvokeMethod.TaskManager.Invoke>();

		// Token: 0x0401200D RID: 73741
		private List<InvokeMethod.TaskManager.Invoke> akInvokeNeedDelete = new List<InvokeMethod.TaskManager.Invoke>();

		// Token: 0x0401200E RID: 73742
		private bool bUpdate;

		// Token: 0x0401200F RID: 73743
		private List<KeyValuePair<IClientFrame, List<UnityAction>>> onGuiPerframeCall = new List<KeyValuePair<IClientFrame, List<UnityAction>>>();

		// Token: 0x020045D3 RID: 17875
		public interface IInvoke
		{
			// Token: 0x060191FD RID: 102909
			bool IsStart();

			// Token: 0x060191FE RID: 102910
			void DoInvoke();
		}

		// Token: 0x020045D4 RID: 17876
		public class Invoke : InvokeMethod.TaskManager.IInvoke
		{
			// Token: 0x060191FF RID: 102911 RVA: 0x00004A35 File Offset: 0x00002E35
			public Invoke(float fStart, float fDelay, UnityAction callback, object target = null)
			{
				this.fStart = fStart;
				this.fDelay = fDelay;
				this.callback = callback;
				this.target = target;
			}

			// Token: 0x06019200 RID: 102912 RVA: 0x00004A5A File Offset: 0x00002E5A
			public bool IsStart()
			{
				return this.fStart + this.fDelay <= Time.time;
			}

			// Token: 0x06019201 RID: 102913 RVA: 0x00004A73 File Offset: 0x00002E73
			public bool NeedRemove()
			{
				return this.bNeedRemove;
			}

			// Token: 0x06019202 RID: 102914 RVA: 0x00004A7B File Offset: 0x00002E7B
			public void SetNeedRemove(bool bRemove = true)
			{
				this.bNeedRemove = bRemove;
			}

			// Token: 0x06019203 RID: 102915 RVA: 0x00004A84 File Offset: 0x00002E84
			public void DoInvoke()
			{
				if (this.callback != null)
				{
					this.callback.Invoke();
				}
			}

			// Token: 0x04012010 RID: 73744
			public float fStart;

			// Token: 0x04012011 RID: 73745
			public float fDelay;

			// Token: 0x04012012 RID: 73746
			public UnityAction callback;

			// Token: 0x04012013 RID: 73747
			public object target;

			// Token: 0x04012014 RID: 73748
			public bool bNeedRemove;
		}

		// Token: 0x020045D5 RID: 17877
		public class IntervalInvoke
		{
			// Token: 0x170020AB RID: 8363
			// (get) Token: 0x06019205 RID: 102917 RVA: 0x007EF87D File Offset: 0x007EDC7D
			// (set) Token: 0x06019206 RID: 102918 RVA: 0x007EF885 File Offset: 0x007EDC85
			public bool NeedRemove
			{
				get
				{
					return this.needRemove;
				}
				set
				{
					this.needRemove = value;
				}
			}

			// Token: 0x06019207 RID: 102919 RVA: 0x007EF88E File Offset: 0x007EDC8E
			public bool IsStart()
			{
				return this.fStart + this.fDelay <= Time.time;
			}

			// Token: 0x06019208 RID: 102920 RVA: 0x007EF8A7 File Offset: 0x007EDCA7
			public bool IsEnd()
			{
				return this.fStart + this.fDelay + this.fLastTime <= Time.time;
			}

			// Token: 0x06019209 RID: 102921 RVA: 0x007EF8C7 File Offset: 0x007EDCC7
			public bool CanInterval()
			{
				return this.fStart + this.fDelay + (float)(this.iInvokeTimes + 1) * this.fIntervalTime <= Time.time;
			}

			// Token: 0x0601920A RID: 102922 RVA: 0x007EF8F1 File Offset: 0x007EDCF1
			public void DoIntervalInvoke()
			{
				if (this.onInterval != null)
				{
					this.onInterval.Invoke();
				}
			}

			// Token: 0x0601920B RID: 102923 RVA: 0x007EF909 File Offset: 0x007EDD09
			public void DoEndInvoke()
			{
				if (this.onEnd != null)
				{
					this.onEnd.Invoke();
				}
			}

			// Token: 0x04012015 RID: 73749
			public static int ms_unique_id;

			// Token: 0x04012016 RID: 73750
			public bool bHasBegin;

			// Token: 0x04012017 RID: 73751
			public int unique_id;

			// Token: 0x04012018 RID: 73752
			public float fStart;

			// Token: 0x04012019 RID: 73753
			public float fDelay;

			// Token: 0x0401201A RID: 73754
			public float fLastTime;

			// Token: 0x0401201B RID: 73755
			public float fIntervalTime = 1f;

			// Token: 0x0401201C RID: 73756
			public int iInvokeTimes;

			// Token: 0x0401201D RID: 73757
			public object target;

			// Token: 0x0401201E RID: 73758
			private bool needRemove;

			// Token: 0x0401201F RID: 73759
			public UnityAction onBegin;

			// Token: 0x04012020 RID: 73760
			public UnityAction onInterval;

			// Token: 0x04012021 RID: 73761
			public UnityAction onEnd;
		}
	}
}
