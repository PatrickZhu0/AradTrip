using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001ED3 RID: 7891
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Action_node6 : Action
	{
		// Token: 0x0601274B RID: 75595 RVA: 0x00566210 File Offset: 0x00564610
		public Action_bt_AutoFight_AutoFight_Fightergirl_Action_node6()
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

		// Token: 0x0601274C RID: 75596 RVA: 0x005662A0 File Offset: 0x005646A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C13C RID: 49468
		private List<Input> method_p0;

		// Token: 0x0400C13D RID: 49469
		private bool method_p1;
	}
}
