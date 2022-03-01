using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004025 RID: 16421
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9 : Action
	{
		// Token: 0x060167AB RID: 92075 RVA: 0x006CDC18 File Offset: 0x006CC018
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 5354;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060167AC RID: 92076 RVA: 0x006CDCA8 File Offset: 0x006CC0A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFF8 RID: 65528
		private List<Input> method_p0;

		// Token: 0x0400FFF9 RID: 65529
		private bool method_p1;
	}
}
