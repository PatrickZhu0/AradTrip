using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200242D RID: 9261
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node41 : Action
	{
		// Token: 0x060131B2 RID: 78258 RVA: 0x005AA534 File Offset: 0x005A8934
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node41()
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
			item.skillID = 1512;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060131B3 RID: 78259 RVA: 0x005AA5C4 File Offset: 0x005A89C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBDA RID: 52186
		private List<Input> method_p0;

		// Token: 0x0400CBDB RID: 52187
		private bool method_p1;
	}
}
