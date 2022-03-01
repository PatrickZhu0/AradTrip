using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F06 RID: 7942
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node75 : Action
	{
		// Token: 0x060127B0 RID: 75696 RVA: 0x00568254 File Offset: 0x00566654
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node75()
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
			item.skillID = 3010;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127B1 RID: 75697 RVA: 0x005682E4 File Offset: 0x005666E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1A5 RID: 49573
		private List<Input> method_p0;

		// Token: 0x0400C1A6 RID: 49574
		private bool method_p1;
	}
}
