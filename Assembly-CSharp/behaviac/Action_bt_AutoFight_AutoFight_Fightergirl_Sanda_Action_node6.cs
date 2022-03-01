using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F34 RID: 7988
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node60 : Action
	{
		// Token: 0x0601280B RID: 75787 RVA: 0x0056A608 File Offset: 0x00568A08
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node60()
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
			item.skillID = 3210;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601280C RID: 75788 RVA: 0x0056A698 File Offset: 0x00568A98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C201 RID: 49665
		private List<Input> method_p0;

		// Token: 0x0400C202 RID: 49666
		private bool method_p1;
	}
}
