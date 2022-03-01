using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BDC RID: 11228
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node54 : Action
	{
		// Token: 0x060140B7 RID: 82103 RVA: 0x006050D8 File Offset: 0x006034D8
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node54()
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
			item.skillID = 21835;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060140B8 RID: 82104 RVA: 0x00605168 File Offset: 0x00603568
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA9C RID: 55964
		private List<Input> method_p0;

		// Token: 0x0400DA9D RID: 55965
		private bool method_p1;
	}
}
