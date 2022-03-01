using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004865 RID: 18533
	public abstract class CompositeStochastic : BehaviorNode
	{
		// Token: 0x0601AA80 RID: 109184 RVA: 0x00839618 File Offset: 0x00837A18
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "RandomGenerator")
				{
					this.m_method = AgentMeta.ParseMethod(property_t.value);
				}
			}
		}

		// Token: 0x0601AA81 RID: 109185 RVA: 0x00839678 File Offset: 0x00837A78
		public bool CheckIfInterrupted(Agent pAgent)
		{
			return base.EvaluteCustomCondition(pAgent);
		}

		// Token: 0x0601AA82 RID: 109186 RVA: 0x0083968E File Offset: 0x00837A8E
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is CompositeStochastic && base.IsValid(pAgent, pTask);
		}

		// Token: 0x040129E1 RID: 76257
		protected IMethod m_method;

		// Token: 0x02004866 RID: 18534
		public class CompositeStochasticTask : CompositeTask
		{
			// Token: 0x0601AA84 RID: 109188 RVA: 0x008396C0 File Offset: 0x00837AC0
			public static int GetRandomValue(IMethod method, Agent pAgent)
			{
				int result;
				if (method != null)
				{
					result = ((CInstanceMember<int>)method).GetValue(pAgent);
				}
				else
				{
					result = 0;
				}
				return result;
			}

			// Token: 0x0601AA85 RID: 109189 RVA: 0x008396EC File Offset: 0x00837AEC
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				CompositeStochastic.CompositeStochasticTask compositeStochasticTask = (CompositeStochastic.CompositeStochasticTask)target;
				compositeStochasticTask.m_set = this.m_set;
			}

			// Token: 0x0601AA86 RID: 109190 RVA: 0x00839714 File Offset: 0x00837B14
			public override void save(ISerializableNode node)
			{
				base.save(node);
				CSerializationID attrId = new CSerializationID("set");
				node.setAttr<List<int>>(attrId, this.m_set);
			}

			// Token: 0x0601AA87 RID: 109191 RVA: 0x00839741 File Offset: 0x00837B41
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AA88 RID: 109192 RVA: 0x0083974A File Offset: 0x00837B4A
			protected override bool onenter(Agent pAgent)
			{
				this.random_child(pAgent);
				this.m_activeChildIndex = 0;
				return true;
			}

			// Token: 0x0601AA89 RID: 109193 RVA: 0x0083975B File Offset: 0x00837B5B
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AA8A RID: 109194 RVA: 0x00839768 File Offset: 0x00837B68
			private void random_child(Agent pAgent)
			{
				CompositeStochastic compositeStochastic = (CompositeStochastic)base.GetNode();
				int count = this.m_children.Count;
				if (this.m_set.Count != count)
				{
					this.m_set.Clear();
					for (int i = 0; i < count; i++)
					{
						this.m_set.Add(i);
					}
				}
				for (int j = 0; j < count; j++)
				{
					int num = count * CompositeStochastic.CompositeStochasticTask.GetRandomValue((compositeStochastic == null) ? null : compositeStochastic.m_method, pAgent);
					int num2 = count * CompositeStochastic.CompositeStochasticTask.GetRandomValue((compositeStochastic == null) ? null : compositeStochastic.m_method, pAgent);
					if (num != num2)
					{
						int value = this.m_set[num];
						this.m_set[num] = this.m_set[num2];
						this.m_set[num2] = value;
					}
				}
			}

			// Token: 0x040129E2 RID: 76258
			protected List<int> m_set = new List<int>();
		}
	}
}
