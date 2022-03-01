using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002967 RID: 10599
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node58 : Action
	{
		// Token: 0x06013C03 RID: 80899 RVA: 0x005E7A1C File Offset: 0x005E5E1C
		public Action_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node58()
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
			item.skillID = 1511;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013C04 RID: 80900 RVA: 0x005E7AAC File Offset: 0x005E5EAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D668 RID: 54888
		private List<Input> method_p0;

		// Token: 0x0400D669 RID: 54889
		private bool method_p1;
	}
}
