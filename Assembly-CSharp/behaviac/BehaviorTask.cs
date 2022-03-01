using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace behaviac
{
	// Token: 0x0200484D RID: 18509
	public abstract class BehaviorTask
	{
		// Token: 0x0601A9BA RID: 108986 RVA: 0x0054FADC File Offset: 0x0054DEDC
		protected BehaviorTask()
		{
			this.m_status = EBTStatus.BT_INVALID;
			this.m_node = null;
			this.m_parent = null;
			this.m_bHasManagingParent = false;
		}

		// Token: 0x0601A9BB RID: 108987 RVA: 0x0054FB00 File Offset: 0x0054DF00
		public static void DestroyTask(BehaviorTask task)
		{
		}

		// Token: 0x0601A9BC RID: 108988 RVA: 0x0054FB02 File Offset: 0x0054DF02
		public virtual void Init(BehaviorNode node)
		{
			this.m_node = node;
			this.m_id = this.m_node.GetId();
		}

		// Token: 0x0601A9BD RID: 108989 RVA: 0x0054FB1C File Offset: 0x0054DF1C
		public virtual void Clear()
		{
			this.m_status = EBTStatus.BT_INVALID;
			this.m_parent = null;
			this.m_id = -1;
		}

		// Token: 0x0601A9BE RID: 108990 RVA: 0x0054FB33 File Offset: 0x0054DF33
		public virtual void copyto(BehaviorTask target)
		{
			target.m_status = this.m_status;
		}

		// Token: 0x0601A9BF RID: 108991 RVA: 0x0054FB41 File Offset: 0x0054DF41
		public virtual void save(ISerializableNode node)
		{
		}

		// Token: 0x0601A9C0 RID: 108992 RVA: 0x0054FB43 File Offset: 0x0054DF43
		public virtual void load(ISerializableNode node)
		{
		}

		// Token: 0x17002296 RID: 8854
		// (get) Token: 0x0601A9C1 RID: 108993 RVA: 0x0054FB48 File Offset: 0x0054DF48
		public BehaviorTreeTask RootTask
		{
			get
			{
				BehaviorTask behaviorTask = this;
				while (behaviorTask.m_parent != null)
				{
					behaviorTask = behaviorTask.m_parent;
				}
				return (BehaviorTreeTask)behaviorTask;
			}
		}

		// Token: 0x0601A9C2 RID: 108994 RVA: 0x0054FB78 File Offset: 0x0054DF78
		public string GetClassNameString()
		{
			if (this.m_node != null)
			{
				return this.m_node.GetClassNameString();
			}
			return "SubBT";
		}

		// Token: 0x0601A9C3 RID: 108995 RVA: 0x0054FBA3 File Offset: 0x0054DFA3
		public int GetId()
		{
			return this.m_id;
		}

		// Token: 0x0601A9C4 RID: 108996 RVA: 0x0054FBAB File Offset: 0x0054DFAB
		public virtual int GetNextStateId()
		{
			return -1;
		}

		// Token: 0x0601A9C5 RID: 108997 RVA: 0x0054FBAE File Offset: 0x0054DFAE
		public virtual BehaviorTask GetCurrentTask()
		{
			return null;
		}

		// Token: 0x0601A9C6 RID: 108998 RVA: 0x0054FBB4 File Offset: 0x0054DFB4
		public EBTStatus exec(Agent pAgent)
		{
			EBTStatus childStatus = EBTStatus.BT_RUNNING;
			return this.exec(pAgent, childStatus);
		}

		// Token: 0x0601A9C7 RID: 108999 RVA: 0x0054FBCC File Offset: 0x0054DFCC
		public EBTStatus exec(Agent pAgent, EBTStatus childStatus)
		{
			bool flag;
			if (this.m_status == EBTStatus.BT_RUNNING)
			{
				flag = true;
			}
			else
			{
				this.m_status = EBTStatus.BT_INVALID;
				flag = this.onenter_action(pAgent);
			}
			if (flag)
			{
				bool flag2 = this.CheckParentUpdatePreconditions(pAgent);
				if (flag2)
				{
					this.m_status = this.update_current(pAgent, childStatus);
				}
				else
				{
					this.m_status = EBTStatus.BT_FAILURE;
					if (this.GetCurrentTask() != null)
					{
						this.update_current(pAgent, EBTStatus.BT_FAILURE);
					}
				}
				if (this.m_status != EBTStatus.BT_RUNNING)
				{
					this.onexit_action(pAgent, this.m_status);
				}
				else
				{
					BranchTask topManageBranchTask = this.GetTopManageBranchTask();
					if (topManageBranchTask != null)
					{
						topManageBranchTask.SetCurrentTask(this);
					}
				}
			}
			else
			{
				this.m_status = EBTStatus.BT_FAILURE;
			}
			return this.m_status;
		}

		// Token: 0x0601A9C8 RID: 109000 RVA: 0x0054FC84 File Offset: 0x0054E084
		private bool CheckParentUpdatePreconditions(Agent pAgent)
		{
			bool flag = true;
			if (this.m_bHasManagingParent)
			{
				bool flag2 = false;
				int num = 0;
				BranchTask parent = this.GetParent();
				BehaviorTask.ms_parents[num++] = this;
				while (parent != null)
				{
					BehaviorTask.ms_parents[num++] = parent;
					if (parent.GetCurrentTask() == this)
					{
						flag2 = true;
						break;
					}
					parent = parent.GetParent();
				}
				if (flag2)
				{
					for (int i = num - 1; i >= 0; i--)
					{
						BehaviorTask behaviorTask = BehaviorTask.ms_parents[i];
						flag = behaviorTask.CheckPreconditions(pAgent, true);
						if (!flag)
						{
							break;
						}
					}
				}
			}
			else
			{
				flag = this.CheckPreconditions(pAgent, true);
			}
			return flag;
		}

		// Token: 0x0601A9C9 RID: 109001 RVA: 0x0054FD34 File Offset: 0x0054E134
		private BranchTask GetTopManageBranchTask()
		{
			BranchTask result = null;
			for (BehaviorTask parent = this.m_parent; parent != null; parent = parent.m_parent)
			{
				if (parent is BehaviorTreeTask)
				{
					result = (BranchTask)parent;
					break;
				}
				if (parent.m_node.IsManagingChildrenAsSubTrees())
				{
					break;
				}
				if (parent is BranchTask)
				{
					result = (BranchTask)parent;
				}
			}
			return result;
		}

		// Token: 0x0601A9CA RID: 109002 RVA: 0x0054FDA0 File Offset: 0x0054E1A0
		private static bool getRunningNodes_handler(BehaviorTask node, Agent pAgent, object user_data)
		{
			if (node.m_status == EBTStatus.BT_RUNNING)
			{
				((List<BehaviorTask>)user_data).Add(node);
			}
			return true;
		}

		// Token: 0x0601A9CB RID: 109003 RVA: 0x0054FDBC File Offset: 0x0054E1BC
		private static bool end_handler(BehaviorTask node, Agent pAgent, object user_data)
		{
			if (node.m_status == EBTStatus.BT_RUNNING || node.m_status == EBTStatus.BT_INVALID)
			{
				EBTStatus status = (EBTStatus)user_data;
				node.onexit_action(pAgent, status);
				node.m_status = status;
				node.SetCurrentTask(null);
			}
			return true;
		}

		// Token: 0x0601A9CC RID: 109004 RVA: 0x0054FDFE File Offset: 0x0054E1FE
		private static bool abort_handler(BehaviorTask node, Agent pAgent, object user_data)
		{
			if (node.m_status == EBTStatus.BT_RUNNING)
			{
				node.onexit_action(pAgent, EBTStatus.BT_FAILURE);
				node.m_status = EBTStatus.BT_FAILURE;
				node.SetCurrentTask(null);
			}
			return true;
		}

		// Token: 0x0601A9CD RID: 109005 RVA: 0x0054FE23 File Offset: 0x0054E223
		private static bool reset_handler(BehaviorTask node, Agent pAgent, object user_data)
		{
			node.m_status = EBTStatus.BT_INVALID;
			node.onreset(pAgent);
			node.SetCurrentTask(null);
			return true;
		}

		// Token: 0x0601A9CE RID: 109006 RVA: 0x0054FE3C File Offset: 0x0054E23C
		public List<BehaviorTask> GetRunningNodes(bool onlyLeaves = true)
		{
			List<BehaviorTask> list = new List<BehaviorTask>();
			this.traverse(true, BehaviorTask.getRunningNodes_handler_, null, list);
			if (onlyLeaves && list.Count > 0)
			{
				List<BehaviorTask> list2 = new List<BehaviorTask>();
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] is LeafTask)
					{
						list2.Add(list[i]);
					}
				}
				return list2;
			}
			return list;
		}

		// Token: 0x0601A9CF RID: 109007 RVA: 0x0054FEAD File Offset: 0x0054E2AD
		public void abort(Agent pAgent)
		{
			this.traverse(true, BehaviorTask.abort_handler_, pAgent, null);
		}

		// Token: 0x0601A9D0 RID: 109008 RVA: 0x0054FEBD File Offset: 0x0054E2BD
		public void reset(Agent pAgent)
		{
			this.traverse(true, BehaviorTask.reset_handler_, pAgent, null);
		}

		// Token: 0x0601A9D1 RID: 109009 RVA: 0x0054FECD File Offset: 0x0054E2CD
		public EBTStatus GetStatus()
		{
			return this.m_status;
		}

		// Token: 0x0601A9D2 RID: 109010 RVA: 0x0054FED5 File Offset: 0x0054E2D5
		public void SetStatus(EBTStatus s)
		{
			this.m_status = s;
		}

		// Token: 0x0601A9D3 RID: 109011 RVA: 0x0054FEDE File Offset: 0x0054E2DE
		public BehaviorNode GetNode()
		{
			return this.m_node;
		}

		// Token: 0x0601A9D4 RID: 109012 RVA: 0x0054FEE6 File Offset: 0x0054E2E6
		public void SetParent(BranchTask parent)
		{
			this.m_parent = parent;
		}

		// Token: 0x0601A9D5 RID: 109013 RVA: 0x0054FEEF File Offset: 0x0054E2EF
		public BranchTask GetParent()
		{
			return this.m_parent;
		}

		// Token: 0x0601A9D6 RID: 109014
		public abstract void traverse(bool childFirst, NodeHandler_t handler, Agent pAgent, object user_data);

		// Token: 0x0601A9D7 RID: 109015 RVA: 0x0054FEF7 File Offset: 0x0054E2F7
		public bool CheckEvents(string eventName, Agent pAgent, Dictionary<uint, IInstantiatedVariable> eventParams)
		{
			return this.m_node.CheckEvents(eventName, pAgent, eventParams);
		}

		// Token: 0x0601A9D8 RID: 109016 RVA: 0x0054FF07 File Offset: 0x0054E307
		public virtual void onreset(Agent pAgent)
		{
		}

		// Token: 0x0601A9D9 RID: 109017 RVA: 0x0054FF09 File Offset: 0x0054E309
		public virtual bool onevent(Agent pAgent, string eventName, Dictionary<uint, IInstantiatedVariable> eventParams)
		{
			return this.m_status != EBTStatus.BT_RUNNING || !this.m_node.HasEvents() || this.CheckEvents(eventName, pAgent, eventParams);
		}

		// Token: 0x0601A9DA RID: 109018 RVA: 0x0054FF38 File Offset: 0x0054E338
		protected virtual EBTStatus update_current(Agent pAgent, EBTStatus childStatus)
		{
			return this.update(pAgent, childStatus);
		}

		// Token: 0x0601A9DB RID: 109019 RVA: 0x0054FF4F File Offset: 0x0054E34F
		protected virtual EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0601A9DC RID: 109020 RVA: 0x0054FF52 File Offset: 0x0054E352
		protected virtual bool onenter(Agent pAgent)
		{
			return true;
		}

		// Token: 0x0601A9DD RID: 109021 RVA: 0x0054FF55 File Offset: 0x0054E355
		protected virtual void onexit(Agent pAgent, EBTStatus status)
		{
		}

		// Token: 0x0601A9DE RID: 109022 RVA: 0x0054FF58 File Offset: 0x0054E358
		public static string GetTickInfo(Agent pAgent, BehaviorTask bt, string action)
		{
			return BehaviorTask.GetTickInfo(pAgent, bt.GetNode(), action);
		}

		// Token: 0x0601A9DF RID: 109023 RVA: 0x0054FF74 File Offset: 0x0054E374
		public static string GetTickInfo(Agent pAgent, BehaviorNode n, string action)
		{
			return string.Empty;
		}

		// Token: 0x0601A9E0 RID: 109024 RVA: 0x0054FF7C File Offset: 0x0054E37C
		public static string GetParentTreeName(Agent pAgent, BehaviorNode n)
		{
			string result = null;
			if (n is ReferencedBehavior)
			{
				n = n.Parent;
			}
			bool flag = false;
			bool flag2 = false;
			while (n != null)
			{
				flag = (n is BehaviorTree);
				flag2 = (n is ReferencedBehavior);
				if (flag || flag2)
				{
					break;
				}
				n = n.Parent;
			}
			if (flag)
			{
				BehaviorTree behaviorTree = n as BehaviorTree;
				result = behaviorTree.GetName();
			}
			else if (flag2)
			{
				ReferencedBehavior referencedBehavior = n as ReferencedBehavior;
				result = referencedBehavior.GetReferencedTree(pAgent);
			}
			return result;
		}

		// Token: 0x0601A9E1 RID: 109025 RVA: 0x00550010 File Offset: 0x0054E410
		private static string GetActionResultStr(EActionResult actionResult)
		{
			return string.Empty;
		}

		// Token: 0x0601A9E2 RID: 109026 RVA: 0x00550017 File Offset: 0x0054E417
		private static void _MY_BREAKPOINT_BREAK_(Agent pAgent, string btMsg, EActionResult actionResult)
		{
		}

		// Token: 0x0601A9E3 RID: 109027 RVA: 0x00550019 File Offset: 0x0054E419
		public static void CHECK_BREAKPOINT(Agent pAgent, BehaviorNode b, string action, EActionResult actionResult)
		{
		}

		// Token: 0x0601A9E4 RID: 109028 RVA: 0x0055001C File Offset: 0x0054E41C
		protected virtual bool CheckPreconditions(Agent pAgent, bool bIsAlive)
		{
			bool result = true;
			if (this.m_node != null && this.m_node.PreconditionsCount > 0)
			{
				result = this.m_node.CheckPreconditions(pAgent, bIsAlive);
			}
			return result;
		}

		// Token: 0x0601A9E5 RID: 109029 RVA: 0x00550058 File Offset: 0x0054E458
		public bool onenter_action(Agent pAgent)
		{
			bool flag = this.CheckPreconditions(pAgent, false);
			if (flag)
			{
				this.m_bHasManagingParent = false;
				this.SetCurrentTask(null);
				flag = this.onenter(pAgent);
				if (!flag)
				{
					return false;
				}
			}
			return flag;
		}

		// Token: 0x0601A9E6 RID: 109030 RVA: 0x00550094 File Offset: 0x0054E494
		public void onexit_action(Agent pAgent, EBTStatus status)
		{
			this.onexit(pAgent, status);
			if (this.m_node != null)
			{
				Effector.EPhase phase = Effector.EPhase.E_SUCCESS;
				if (status == EBTStatus.BT_FAILURE)
				{
					phase = Effector.EPhase.E_FAILURE;
				}
				this.m_node.ApplyEffects(pAgent, phase);
			}
		}

		// Token: 0x0601A9E7 RID: 109031 RVA: 0x005500D1 File Offset: 0x0054E4D1
		public void SetHasManagingParent(bool bHasManagingParent)
		{
			this.m_bHasManagingParent = bHasManagingParent;
		}

		// Token: 0x0601A9E8 RID: 109032 RVA: 0x005500DA File Offset: 0x0054E4DA
		public virtual void SetCurrentTask(BehaviorTask task)
		{
		}

		// Token: 0x0601A9E9 RID: 109033 RVA: 0x005500DC File Offset: 0x0054E4DC
		// Note: this type is marked as 'beforefieldinit'.
		static BehaviorTask()
		{
			if (BehaviorTask.<>f__mg$cache0 == null)
			{
				BehaviorTask.<>f__mg$cache0 = new NodeHandler_t(BehaviorTask.getRunningNodes_handler);
			}
			BehaviorTask.getRunningNodes_handler_ = BehaviorTask.<>f__mg$cache0;
			if (BehaviorTask.<>f__mg$cache1 == null)
			{
				BehaviorTask.<>f__mg$cache1 = new NodeHandler_t(BehaviorTask.end_handler);
			}
			BehaviorTask.end_handler_ = BehaviorTask.<>f__mg$cache1;
			if (BehaviorTask.<>f__mg$cache2 == null)
			{
				BehaviorTask.<>f__mg$cache2 = new NodeHandler_t(BehaviorTask.abort_handler);
			}
			BehaviorTask.abort_handler_ = BehaviorTask.<>f__mg$cache2;
			if (BehaviorTask.<>f__mg$cache3 == null)
			{
				BehaviorTask.<>f__mg$cache3 = new NodeHandler_t(BehaviorTask.reset_handler);
			}
			BehaviorTask.reset_handler_ = BehaviorTask.<>f__mg$cache3;
		}

		// Token: 0x040129B3 RID: 76211
		private const int kMaxParentsCount = 512;

		// Token: 0x040129B4 RID: 76212
		private static BehaviorTask[] ms_parents = new BehaviorTask[512];

		// Token: 0x040129B5 RID: 76213
		protected static NodeHandler_t getRunningNodes_handler_;

		// Token: 0x040129B6 RID: 76214
		protected static NodeHandler_t end_handler_;

		// Token: 0x040129B7 RID: 76215
		protected static NodeHandler_t abort_handler_;

		// Token: 0x040129B8 RID: 76216
		protected static NodeHandler_t reset_handler_;

		// Token: 0x040129B9 RID: 76217
		public EBTStatus m_status;

		// Token: 0x040129BA RID: 76218
		protected BehaviorNode m_node;

		// Token: 0x040129BB RID: 76219
		protected BranchTask m_parent;

		// Token: 0x040129BC RID: 76220
		protected int m_id;

		// Token: 0x040129BD RID: 76221
		protected bool m_bHasManagingParent;

		// Token: 0x040129BE RID: 76222
		[CompilerGenerated]
		private static NodeHandler_t <>f__mg$cache0;

		// Token: 0x040129BF RID: 76223
		[CompilerGenerated]
		private static NodeHandler_t <>f__mg$cache1;

		// Token: 0x040129C0 RID: 76224
		[CompilerGenerated]
		private static NodeHandler_t <>f__mg$cache2;

		// Token: 0x040129C1 RID: 76225
		[CompilerGenerated]
		private static NodeHandler_t <>f__mg$cache3;
	}
}
