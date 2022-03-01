using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020036CB RID: 14027
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node9 : Action
	{
		// Token: 0x060155AE RID: 87470 RVA: 0x006712F4 File Offset: 0x0066F6F4
		public Action_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongda_node9()
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
			item.skillID = 5433;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060155AF RID: 87471 RVA: 0x00671384 File Offset: 0x0066F784
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF80 RID: 61312
		private List<Input> method_p0;

		// Token: 0x0400EF81 RID: 61313
		private bool method_p1;
	}
}
