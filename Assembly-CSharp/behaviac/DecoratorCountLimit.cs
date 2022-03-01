using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004894 RID: 18580
	public class DecoratorCountLimit : DecoratorCount
	{
		// Token: 0x0601AB71 RID: 109425 RVA: 0x0083AAEB File Offset: 0x00838EEB
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB72 RID: 109426 RVA: 0x0083AAF6 File Offset: 0x00838EF6
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorCountLimit && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB73 RID: 109427 RVA: 0x0083AB14 File Offset: 0x00838F14
		protected override BehaviorTask createTask()
		{
			return new DecoratorCountLimit.DecoratorCountLimitTask();
		}

		// Token: 0x0601AB74 RID: 109428 RVA: 0x0083AB28 File Offset: 0x00838F28
		public bool CheckIfReInit(Agent pAgent)
		{
			return base.EvaluteCustomCondition(pAgent);
		}

		// Token: 0x02004895 RID: 18581
		private class DecoratorCountLimitTask : DecoratorCount.DecoratorCountTask
		{
			// Token: 0x0601AB76 RID: 109430 RVA: 0x0083AB48 File Offset: 0x00838F48
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				DecoratorCountLimit.DecoratorCountLimitTask decoratorCountLimitTask = (DecoratorCountLimit.DecoratorCountLimitTask)target;
				decoratorCountLimitTask.m_bInited = this.m_bInited;
			}

			// Token: 0x0601AB77 RID: 109431 RVA: 0x0083AB70 File Offset: 0x00838F70
			public override void save(ISerializableNode node)
			{
				base.save(node);
				CSerializationID attrId = new CSerializationID("inited");
				node.setAttr<bool>(attrId, this.m_bInited);
			}

			// Token: 0x0601AB78 RID: 109432 RVA: 0x0083AB9D File Offset: 0x00838F9D
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB79 RID: 109433 RVA: 0x0083ABA8 File Offset: 0x00838FA8
			protected override bool onenter(Agent pAgent)
			{
				DecoratorCountLimit decoratorCountLimit = this.m_node as DecoratorCountLimit;
				if (decoratorCountLimit.CheckIfReInit(pAgent))
				{
					this.m_bInited = false;
				}
				if (!this.m_bInited)
				{
					this.m_bInited = true;
					int count = base.GetCount(pAgent);
					this.m_n = count;
				}
				if (this.m_n > 0)
				{
					this.m_n--;
					return true;
				}
				return this.m_n != 0 && this.m_n == -1;
			}

			// Token: 0x0601AB7A RID: 109434 RVA: 0x0083AC2D File Offset: 0x0083902D
			protected override EBTStatus decorate(EBTStatus status)
			{
				return status;
			}

			// Token: 0x04012A04 RID: 76292
			private bool m_bInited;
		}
	}
}
