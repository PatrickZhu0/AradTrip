using System;
using System.Collections.Generic;

// Token: 0x0200415E RID: 16734
[LoggerModel("Chapter")]
public class BeStateManager<T> where T : IComparable
{
	// Token: 0x17001F2E RID: 7982
	// (get) Token: 0x06016E24 RID: 93732 RVA: 0x00709CA0 File Offset: 0x007080A0
	// (set) Token: 0x06016E25 RID: 93733 RVA: 0x00709CA8 File Offset: 0x007080A8
	public T state
	{
		get
		{
			return this.mState;
		}
		set
		{
			if (this.mState.CompareTo(value) != 0)
			{
				if (this.mLastState.CompareTo(this.mState) != 0)
				{
				}
				this.mState = value;
			}
		}
	}

	// Token: 0x17001F2F RID: 7983
	// (get) Token: 0x06016E26 RID: 93734 RVA: 0x00709CF9 File Offset: 0x007080F9
	public T lastState
	{
		get
		{
			return this.mLastState;
		}
	}

	// Token: 0x06016E27 RID: 93735 RVA: 0x00709D04 File Offset: 0x00708104
	protected BeStateManager<T>.IStateEventManager _addState(T toState, BeStateManager<T>.Do enter, BeStateManager<T>.Do exit)
	{
		BeStateManager<T>.StateNode stateNode = new BeStateManager<T>.StateNode
		{
			stateEnter = enter,
			stateExit = exit
		};
		this.list.Add(new KeyValuePair<T, BeStateManager<T>.StateNode>(toState, stateNode));
		return stateNode;
	}

	// Token: 0x06016E28 RID: 93736 RVA: 0x00709D3C File Offset: 0x0070813C
	protected void _clearAllStates()
	{
		for (int i = 0; i < this.list.Count; i++)
		{
			T key = this.list[i].Key;
			if (key.CompareTo(this.mItCurState) == 0)
			{
				this.list[i].Value.stateExit(default(T));
			}
			this.list[i].Value.Clear();
		}
		this.list.Clear();
	}

	// Token: 0x06016E29 RID: 93737 RVA: 0x00709DE4 File Offset: 0x007081E4
	protected void _resetState()
	{
		this.mLastState = default(T);
		for (int i = 0; i < this.list.Count; i++)
		{
			BeStateManager<T>.StateNode value = this.list[i].Value;
			for (int j = 0; j < value.nodes.Count; j++)
			{
				value.nodes[j].Reset();
			}
		}
	}

	// Token: 0x06016E2A RID: 93738 RVA: 0x00709E64 File Offset: 0x00708264
	protected void _updateState(int delta)
	{
		if (this.mLastState.CompareTo(this.mState) == 0)
		{
			for (int i = 0; i < this.list.Count; i++)
			{
				T key = this.list[i].Key;
				if (key.CompareTo(this.mState) == 0)
				{
					List<BeStateManager<T>.IEventNode> nodes = this.list[i].Value.nodes;
					for (int j = 0; j < nodes.Count; j++)
					{
						if (!nodes[j].CanRemove() && nodes[j].CanExcute(delta))
						{
							nodes[j].Excute();
						}
					}
					break;
				}
			}
			return;
		}
		this.mItCurState = default(T);
		this.mItLastState = default(T);
		this.mStackDeep = 0;
		while (this.mItCurState.CompareTo(this.mState) != 0 && ++this.mStackDeep < 10)
		{
			this.mItCurState = this.mState;
			this.mItLastState = this.mLastState;
			for (int k = 0; k < this.list.Count; k++)
			{
				T key2 = this.list[k].Key;
				if (key2.CompareTo(this.mItLastState) == 0 && this.list[k].Value != null && this.list[k].Value.stateExit != null)
				{
					this.list[k].Value.stateExit(this.mItCurState);
					break;
				}
			}
			if (this.mItLastState.CompareTo(this.mLastState) != 0)
			{
				Logger.LogErrorFormat("[BeStateManager] 无法再退出函数中修改状态，回退上一个状态至 mLastState {0}", new object[]
				{
					this.mItLastState
				});
				this.mLastState = this.mItLastState;
			}
			if (this.mItCurState.CompareTo(this.mState) != 0)
			{
				Logger.LogErrorFormat("[BeStateManager] 无法再退出函数中修改状态, 回退当前状态 mState  {0}", new object[]
				{
					this.mItCurState
				});
				this.mState = this.mItCurState;
			}
			this.mLastState = this.mItCurState;
			for (int l = 0; l < this.list.Count; l++)
			{
				T key3 = this.list[l].Key;
				if (key3.CompareTo(this.mItCurState) == 0 && this.list[l].Value != null && this.list[l].Value.stateEnter != null)
				{
					List<BeStateManager<T>.IEventNode> nodes2 = this.list[l].Value.nodes;
					for (int m = 0; m < nodes2.Count; m++)
					{
						if (!nodes2[m].CanRemove() && nodes2[m].GetReentrantType() == BeStateManager<T>.eBeStateReentrantType.Reset)
						{
							nodes2[m].Reset();
						}
					}
					this.list[l].Value.stateEnter(this.mItLastState);
					break;
				}
			}
		}
		if (this.mStackDeep > 10)
		{
			Logger.LogError("[BeStateManager] 超过最大栈深度");
		}
	}

	// Token: 0x040105CF RID: 67023
	private const int kMaxStackDeep = 10;

	// Token: 0x040105D0 RID: 67024
	private int mStackDeep;

	// Token: 0x040105D1 RID: 67025
	private List<KeyValuePair<T, BeStateManager<T>.StateNode>> list = new List<KeyValuePair<T, BeStateManager<T>.StateNode>>();

	// Token: 0x040105D2 RID: 67026
	private T mLastState = default(T);

	// Token: 0x040105D3 RID: 67027
	private T mState = default(T);

	// Token: 0x040105D4 RID: 67028
	private T mItCurState;

	// Token: 0x040105D5 RID: 67029
	private T mItLastState;

	// Token: 0x0200415F RID: 16735
	// (Invoke) Token: 0x06016E2C RID: 93740
	protected delegate void Do(T lastState);

	// Token: 0x02004160 RID: 16736
	// (Invoke) Token: 0x06016E30 RID: 93744
	protected delegate void EventDo();

	// Token: 0x02004161 RID: 16737
	protected enum eBeStateReentrantType
	{
		// Token: 0x040105D7 RID: 67031
		Reset,
		// Token: 0x040105D8 RID: 67032
		Continue
	}

	// Token: 0x02004162 RID: 16738
	protected class BaseEventNode : BeStateManager<T>.IEventNode
	{
		// Token: 0x06016E33 RID: 93747 RVA: 0x0070A26A File Offset: 0x0070866A
		public BaseEventNode(string name, int time, BeStateManager<T>.EventDo call, BeStateManager<T>.eBeStateReentrantType type)
		{
			this.time = time;
			this.name = name;
			this.call = call;
			this.type = type;
		}

		// Token: 0x06016E34 RID: 93748 RVA: 0x0070A28F File Offset: 0x0070868F
		public void Init()
		{
			this.alltime = this.time;
		}

		// Token: 0x06016E35 RID: 93749 RVA: 0x0070A29D File Offset: 0x0070869D
		public void Reset()
		{
			this.time = this.alltime;
		}

		// Token: 0x06016E36 RID: 93750 RVA: 0x0070A2AB File Offset: 0x007086AB
		public void UnInit()
		{
			this.time = 0;
			this.call = null;
		}

		// Token: 0x06016E37 RID: 93751 RVA: 0x0070A2BC File Offset: 0x007086BC
		public bool Excute()
		{
			bool result;
			try
			{
				if (this.call != null)
				{
					this.call();
				}
				this.time = -1;
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06016E38 RID: 93752 RVA: 0x0070A308 File Offset: 0x00708708
		public BeStateManager<T>.eBeStateReentrantType GetReentrantType()
		{
			return this.type;
		}

		// Token: 0x06016E39 RID: 93753 RVA: 0x0070A310 File Offset: 0x00708710
		public string GetName()
		{
			return this.name;
		}

		// Token: 0x06016E3A RID: 93754 RVA: 0x0070A318 File Offset: 0x00708718
		public bool CanExcute(int delta)
		{
			this.time -= delta;
			return this.time < 0;
		}

		// Token: 0x06016E3B RID: 93755 RVA: 0x0070A331 File Offset: 0x00708731
		public bool CanRemove()
		{
			return this.time < 0;
		}

		// Token: 0x040105D9 RID: 67033
		public int time;

		// Token: 0x040105DA RID: 67034
		public string name;

		// Token: 0x040105DB RID: 67035
		public BeStateManager<T>.EventDo call;

		// Token: 0x040105DC RID: 67036
		private int alltime;

		// Token: 0x040105DD RID: 67037
		public BeStateManager<T>.eBeStateReentrantType type;
	}

	// Token: 0x02004163 RID: 16739
	protected interface IEventNode
	{
		// Token: 0x06016E3C RID: 93756
		BeStateManager<T>.eBeStateReentrantType GetReentrantType();

		// Token: 0x06016E3D RID: 93757
		void Init();

		// Token: 0x06016E3E RID: 93758
		void UnInit();

		// Token: 0x06016E3F RID: 93759
		void Reset();

		// Token: 0x06016E40 RID: 93760
		bool CanExcute(int delta);

		// Token: 0x06016E41 RID: 93761
		bool CanRemove();

		// Token: 0x06016E42 RID: 93762
		bool Excute();

		// Token: 0x06016E43 RID: 93763
		string GetName();
	}

	// Token: 0x02004164 RID: 16740
	protected interface IStateEventManager
	{
		// Token: 0x06016E44 RID: 93764
		void Add(BeStateManager<T>.IEventNode node);

		// Token: 0x06016E45 RID: 93765
		void Remove(BeStateManager<T>.IEventNode node);

		// Token: 0x06016E46 RID: 93766
		void Clear();
	}

	// Token: 0x02004165 RID: 16741
	protected class StateNode : BeStateManager<T>.IStateEventManager
	{
		// Token: 0x06016E48 RID: 93768 RVA: 0x0070A34F File Offset: 0x0070874F
		public void Add(BeStateManager<T>.IEventNode node)
		{
			if (node != null)
			{
				node.Init();
				this.nodes.Add(node);
			}
		}

		// Token: 0x06016E49 RID: 93769 RVA: 0x0070A369 File Offset: 0x00708769
		public void Remove(BeStateManager<T>.IEventNode node)
		{
			if (node != null)
			{
				node.UnInit();
				this.nodes.Remove(node);
			}
		}

		// Token: 0x06016E4A RID: 93770 RVA: 0x0070A384 File Offset: 0x00708784
		public void Clear()
		{
			if (this.nodes != null)
			{
				for (int i = 0; i < this.nodes.Count; i++)
				{
					this.nodes[i].UnInit();
				}
				this.nodes.Clear();
			}
		}

		// Token: 0x040105DE RID: 67038
		public BeStateManager<T>.Do stateEnter;

		// Token: 0x040105DF RID: 67039
		public BeStateManager<T>.Do stateExit;

		// Token: 0x040105E0 RID: 67040
		public List<BeStateManager<T>.IEventNode> nodes = new List<BeStateManager<T>.IEventNode>();
	}
}
