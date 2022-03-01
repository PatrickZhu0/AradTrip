using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002BD6 RID: 11222
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node21 : Action
	{
		// Token: 0x060140AB RID: 82091 RVA: 0x00604ED0 File Offset: 0x006032D0
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node21()
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
			item.skillID = 21833;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060140AC RID: 82092 RVA: 0x00604F60 File Offset: 0x00603360
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA96 RID: 55958
		private List<Input> method_p0;

		// Token: 0x0400DA97 RID: 55959
		private bool method_p1;
	}
}
