using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BD9 RID: 11225
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node45 : Action
	{
		// Token: 0x060140B1 RID: 82097 RVA: 0x00604FD4 File Offset: 0x006033D4
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node45()
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
			item.skillID = 21834;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060140B2 RID: 82098 RVA: 0x00605064 File Offset: 0x00603464
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA99 RID: 55961
		private List<Input> method_p0;

		// Token: 0x0400DA9A RID: 55962
		private bool method_p1;
	}
}
