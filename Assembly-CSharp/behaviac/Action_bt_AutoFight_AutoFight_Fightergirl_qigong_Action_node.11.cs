using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F1F RID: 7967
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node51 : Action
	{
		// Token: 0x060127E2 RID: 75746 RVA: 0x00568E68 File Offset: 0x00567268
		public Action_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node51()
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
			item.skillID = 3009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127E3 RID: 75747 RVA: 0x00568EF8 File Offset: 0x005672F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1DA RID: 49626
		private List<Input> method_p0;

		// Token: 0x0400C1DB RID: 49627
		private bool method_p1;
	}
}
