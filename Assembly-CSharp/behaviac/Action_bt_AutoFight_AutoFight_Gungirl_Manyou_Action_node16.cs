using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002504 RID: 9476
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node16 : Action
	{
		// Token: 0x06013352 RID: 78674 RVA: 0x005B3C4C File Offset: 0x005B204C
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node16()
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
			item.skillID = 2507;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013353 RID: 78675 RVA: 0x005B3CDC File Offset: 0x005B20DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD72 RID: 52594
		private List<Input> method_p0;

		// Token: 0x0400CD73 RID: 52595
		private bool method_p1;
	}
}
