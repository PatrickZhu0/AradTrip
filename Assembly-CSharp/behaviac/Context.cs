using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004757 RID: 18263
	public class Context
	{
		// Token: 0x0601A408 RID: 107528 RVA: 0x00825A1B File Offset: 0x00823E1B
		private Context(int contextId)
		{
			this.m_context_id = contextId;
			this.m_IsExecuting = false;
		}

		// Token: 0x17002262 RID: 8802
		// (get) Token: 0x0601A409 RID: 107529 RVA: 0x00825A59 File Offset: 0x00823E59
		// (set) Token: 0x0601A40A RID: 107530 RVA: 0x00825A77 File Offset: 0x00823E77
		public List<Context.HeapItem_t> Agents
		{
			get
			{
				if (this.m_agents == null)
				{
					this.m_agents = new List<Context.HeapItem_t>();
				}
				return this.m_agents;
			}
			set
			{
				this.m_agents = value;
			}
		}

		// Token: 0x0601A40B RID: 107531 RVA: 0x00825A80 File Offset: 0x00823E80
		private int GetContextId()
		{
			return this.m_context_id;
		}

		// Token: 0x0601A40C RID: 107532 RVA: 0x00825A88 File Offset: 0x00823E88
		public static Context GetContext(int contextId)
		{
			if (Context.ms_contexts.ContainsKey(contextId))
			{
				return Context.ms_contexts[contextId];
			}
			Context context = new Context(contextId);
			Context.ms_contexts[contextId] = context;
			return context;
		}

		// Token: 0x0601A40D RID: 107533 RVA: 0x00825AC8 File Offset: 0x00823EC8
		public static void Cleanup(int contextId)
		{
			if (Context.ms_contexts != null)
			{
				if (contextId == -1)
				{
					Context.ms_contexts.Clear();
				}
				else if (Context.ms_contexts.ContainsKey(contextId))
				{
					Context.ms_contexts.Remove(contextId);
				}
			}
		}

		// Token: 0x0601A40E RID: 107534 RVA: 0x00825B18 File Offset: 0x00823F18
		public static void AddAgent(Agent pAgent)
		{
			if (!object.ReferenceEquals(pAgent, null))
			{
				Context context = Context.GetContext(pAgent.GetContextId());
				if (context != null)
				{
					if (context.m_IsExecuting)
					{
						context.delayAddedAgents.Add(pAgent);
					}
					else
					{
						context.addAgent_(pAgent);
					}
				}
			}
		}

		// Token: 0x0601A40F RID: 107535 RVA: 0x00825B68 File Offset: 0x00823F68
		public static void RemoveAgent(Agent pAgent)
		{
			if (!object.ReferenceEquals(pAgent, null))
			{
				Context context = Context.GetContext(pAgent.GetContextId());
				if (context != null)
				{
					if (context.m_IsExecuting)
					{
						context.delayRemovedAgents.Add(pAgent);
					}
					else
					{
						context.removeAgent_(pAgent);
					}
				}
			}
		}

		// Token: 0x0601A410 RID: 107536 RVA: 0x00825BB8 File Offset: 0x00823FB8
		private void DelayProcessingAgents()
		{
			if (this.delayAddedAgents.Count > 0)
			{
				for (int i = 0; i < this.delayAddedAgents.Count; i++)
				{
					this.addAgent_(this.delayAddedAgents[i]);
				}
				this.delayAddedAgents.Clear();
			}
			if (this.delayRemovedAgents.Count > 0)
			{
				for (int j = 0; j < this.delayRemovedAgents.Count; j++)
				{
					this.removeAgent_(this.delayRemovedAgents[j]);
				}
				this.delayRemovedAgents.Clear();
			}
		}

		// Token: 0x0601A411 RID: 107537 RVA: 0x00825C5C File Offset: 0x0082405C
		private void addAgent_(Agent pAgent)
		{
			int id = pAgent.GetId();
			int priority = pAgent.GetPriority();
			int num = this.Agents.FindIndex((Context.HeapItem_t h) => h.priority == priority);
			if (num == -1)
			{
				Context.HeapItem_t item = default(Context.HeapItem_t);
				item.agents = new Dictionary<int, Agent>();
				item.priority = priority;
				item.agents[id] = pAgent;
				this.Agents.Add(item);
			}
			else
			{
				this.Agents[num].agents[id] = pAgent;
			}
		}

		// Token: 0x0601A412 RID: 107538 RVA: 0x00825D00 File Offset: 0x00824100
		private void removeAgent_(Agent pAgent)
		{
			int id = pAgent.GetId();
			int priority = pAgent.GetPriority();
			int num = this.Agents.FindIndex((Context.HeapItem_t h) => h.priority == priority);
			if (num != -1 && this.Agents[num].agents.ContainsKey(id))
			{
				this.Agents[num].agents.Remove(id);
			}
		}

		// Token: 0x0601A413 RID: 107539 RVA: 0x00825D80 File Offset: 0x00824180
		public static void execAgents(int contextId)
		{
			if (contextId >= 0)
			{
				Context context = Context.GetContext(contextId);
				if (context != null)
				{
					context.execAgents_();
				}
			}
			else
			{
				foreach (KeyValuePair<int, Context> keyValuePair in Context.ms_contexts)
				{
					Context value = keyValuePair.Value;
					if (value != null)
					{
						value.execAgents_();
					}
				}
			}
		}

		// Token: 0x0601A414 RID: 107540 RVA: 0x00825DE4 File Offset: 0x008241E4
		private void execAgents_()
		{
			if (!Workspace.Instance.IsExecAgents)
			{
				return;
			}
			this.m_IsExecuting = true;
			this.Agents.Sort();
			for (int i = 0; i < this.Agents.Count; i++)
			{
				foreach (KeyValuePair<int, Agent> keyValuePair in this.Agents[i].agents)
				{
					Agent value = keyValuePair.Value;
					if (value.IsActive())
					{
						value.btexec();
						if (!Workspace.Instance.IsExecAgents)
						{
							break;
						}
					}
				}
			}
			this.m_IsExecuting = false;
			this.DelayProcessingAgents();
		}

		// Token: 0x0601A415 RID: 107541 RVA: 0x00825EA0 File Offset: 0x008242A0
		private void LogCurrentState()
		{
			string text = string.Format("LogCurrentStates {0} {1}", this.m_context_id, this.Agents.Count);
			for (int i = 0; i < this.Agents.Count; i++)
			{
				Dictionary<int, Agent>.ValueCollection.Enumerator enumerator = this.Agents[i].agents.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsMasked())
					{
						enumerator.Current.LogVariables(true);
						enumerator.Current.LogRunningNodes();
					}
				}
			}
		}

		// Token: 0x0601A416 RID: 107542 RVA: 0x00825F4C File Offset: 0x0082434C
		public static void LogCurrentStates(int contextId)
		{
			if (contextId >= 0)
			{
				Context context = Context.GetContext(contextId);
				if (context != null)
				{
					context.LogCurrentState();
				}
			}
			else
			{
				foreach (Context context2 in Context.ms_contexts.Values)
				{
					context2.LogCurrentState();
				}
			}
		}

		// Token: 0x0601A417 RID: 107543 RVA: 0x00825FA5 File Offset: 0x008243A5
		private void CleanupInstances()
		{
			this.m_namedAgents.Clear();
		}

		// Token: 0x0601A418 RID: 107544 RVA: 0x00825FB4 File Offset: 0x008243B4
		private static bool GetClassNameString(string variableName, ref string className)
		{
			int num = variableName.LastIndexOf(':');
			if (num > 0)
			{
				className = variableName.Substring(0, num - 1);
				return true;
			}
			className = variableName;
			return true;
		}

		// Token: 0x0601A419 RID: 107545 RVA: 0x00825FE4 File Offset: 0x008243E4
		public bool BindInstance(Agent pAgentInstance, string agentInstanceName)
		{
			if (string.IsNullOrEmpty(agentInstanceName))
			{
				agentInstanceName = pAgentInstance.GetType().FullName;
			}
			if (Agent.IsNameRegistered(agentInstanceName))
			{
				string registeredClassName = Agent.GetRegisteredClassName(agentInstanceName);
				if (Agent.IsDerived(pAgentInstance, registeredClassName))
				{
					this.m_namedAgents[agentInstanceName] = pAgentInstance;
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601A41A RID: 107546 RVA: 0x0082603C File Offset: 0x0082443C
		public bool BindInstance(Agent pAgentInstance)
		{
			return this.BindInstance(pAgentInstance, null);
		}

		// Token: 0x0601A41B RID: 107547 RVA: 0x00826046 File Offset: 0x00824446
		public bool UnbindInstance(string agentInstanceName)
		{
			if (Agent.IsNameRegistered(agentInstanceName))
			{
				if (this.m_namedAgents.ContainsKey(agentInstanceName))
				{
					this.m_namedAgents.Remove(agentInstanceName);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601A41C RID: 107548 RVA: 0x0082607C File Offset: 0x0082447C
		public bool UnbindInstance<T>()
		{
			string fullName = typeof(T).FullName;
			return this.UnbindInstance(fullName);
		}

		// Token: 0x0601A41D RID: 107549 RVA: 0x008260A0 File Offset: 0x008244A0
		public Agent GetInstance(string agentInstanceName)
		{
			bool flag = !string.IsNullOrEmpty(agentInstanceName);
			if (!flag)
			{
				return null;
			}
			string key = null;
			Context.GetClassNameString(agentInstanceName, ref key);
			if (this.m_namedAgents.ContainsKey(key))
			{
				return this.m_namedAgents[key];
			}
			return null;
		}

		// Token: 0x040126E9 RID: 75497
		private static Dictionary<int, Context> ms_contexts = new Dictionary<int, Context>();

		// Token: 0x040126EA RID: 75498
		private Dictionary<string, Agent> m_namedAgents = new Dictionary<string, Agent>();

		// Token: 0x040126EB RID: 75499
		private List<Context.HeapItem_t> m_agents;

		// Token: 0x040126EC RID: 75500
		private int m_context_id = -1;

		// Token: 0x040126ED RID: 75501
		private bool m_IsExecuting;

		// Token: 0x040126EE RID: 75502
		private List<Agent> delayAddedAgents = new List<Agent>();

		// Token: 0x040126EF RID: 75503
		private List<Agent> delayRemovedAgents = new List<Agent>();

		// Token: 0x02004758 RID: 18264
		public struct HeapItem_t : IComparable<Context.HeapItem_t>
		{
			// Token: 0x0601A41F RID: 107551 RVA: 0x008260F7 File Offset: 0x008244F7
			public int CompareTo(Context.HeapItem_t other)
			{
				if (this.priority < other.priority)
				{
					return -1;
				}
				if (this.priority > other.priority)
				{
					return 1;
				}
				return 0;
			}

			// Token: 0x040126F0 RID: 75504
			public int priority;

			// Token: 0x040126F1 RID: 75505
			public Dictionary<int, Agent> agents;
		}
	}
}
