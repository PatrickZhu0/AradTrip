using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002612 RID: 9746
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node55 : Action
	{
		// Token: 0x0601356A RID: 79210 RVA: 0x005C0CAC File Offset: 0x005BF0AC
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node55()
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
			item.skillID = 1113;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601356B RID: 79211 RVA: 0x005C0D3C File Offset: 0x005BF13C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFB6 RID: 53174
		private List<Input> method_p0;

		// Token: 0x0400CFB7 RID: 53175
		private bool method_p1;
	}
}
