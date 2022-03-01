using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BEE RID: 11246
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node2 : Action
	{
		// Token: 0x060140DB RID: 82139 RVA: 0x006055F8 File Offset: 0x006039F8
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 100;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 21959;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060140DC RID: 82140 RVA: 0x00605689 File Offset: 0x00603A89
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DABE RID: 55998
		private List<Input> method_p0;

		// Token: 0x0400DABF RID: 55999
		private bool method_p1;
	}
}
