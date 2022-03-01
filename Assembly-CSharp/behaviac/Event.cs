using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004840 RID: 18496
	public class Event : ConditionBase
	{
		// Token: 0x0601A956 RID: 108886 RVA: 0x008380DC File Offset: 0x008364DC
		public Event()
		{
			this.m_eventName = null;
			this.m_bTriggeredOnce = false;
			this.m_triggerMode = TriggerMode.TM_Transfer;
		}

		// Token: 0x0601A957 RID: 108887 RVA: 0x008380FC File Offset: 0x008364FC
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Task")
				{
					this.m_event = AgentMeta.ParseMethod(property_t.value, ref this.m_eventName);
				}
				else if (property_t.name == "ReferenceFilename")
				{
					this.m_referencedBehaviorPath = property_t.value;
					if (Config.PreloadBehaviors)
					{
						BehaviorTree behaviorTree = Workspace.Instance.LoadBehaviorTree(this.m_referencedBehaviorPath);
					}
				}
				else if (property_t.name == "TriggeredOnce")
				{
					this.m_bTriggeredOnce = (property_t.value == "true");
				}
				else if (property_t.name == "TriggerMode")
				{
					if (property_t.value == "Transfer")
					{
						this.m_triggerMode = TriggerMode.TM_Transfer;
					}
					else if (property_t.value == "Return")
					{
						this.m_triggerMode = TriggerMode.TM_Return;
					}
				}
			}
		}

		// Token: 0x0601A958 RID: 108888 RVA: 0x00838233 File Offset: 0x00836633
		public string GetEventName()
		{
			return this.m_eventName;
		}

		// Token: 0x0601A959 RID: 108889 RVA: 0x0083823B File Offset: 0x0083663B
		public bool TriggeredOnce()
		{
			return this.m_bTriggeredOnce;
		}

		// Token: 0x0601A95A RID: 108890 RVA: 0x00838243 File Offset: 0x00836643
		public TriggerMode GetTriggerMode()
		{
			return this.m_triggerMode;
		}

		// Token: 0x0601A95B RID: 108891 RVA: 0x0083824C File Offset: 0x0083664C
		public void switchTo(Agent pAgent, Dictionary<uint, IInstantiatedVariable> eventParams)
		{
			if (!string.IsNullOrEmpty(this.m_referencedBehaviorPath) && !object.ReferenceEquals(pAgent, null))
			{
				TriggerMode triggerMode = this.GetTriggerMode();
				pAgent.bteventtree(pAgent, this.m_referencedBehaviorPath, triggerMode);
				pAgent.CurrentTreeTask.AddVariables(eventParams);
				pAgent.btexec();
			}
		}

		// Token: 0x0601A95C RID: 108892 RVA: 0x0083829D File Offset: 0x0083669D
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Event && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601A95D RID: 108893 RVA: 0x008382B9 File Offset: 0x008366B9
		protected override BehaviorTask createTask()
		{
			return null;
		}

		// Token: 0x04012962 RID: 76130
		protected IMethod m_event;

		// Token: 0x04012963 RID: 76131
		protected string m_eventName;

		// Token: 0x04012964 RID: 76132
		protected string m_referencedBehaviorPath;

		// Token: 0x04012965 RID: 76133
		protected TriggerMode m_triggerMode;

		// Token: 0x04012966 RID: 76134
		protected bool m_bTriggeredOnce;
	}
}
