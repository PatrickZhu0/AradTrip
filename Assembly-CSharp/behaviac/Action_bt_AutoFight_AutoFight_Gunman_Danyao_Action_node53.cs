using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025AC RID: 9644
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node53 : Action
	{
		// Token: 0x0601349F RID: 79007 RVA: 0x005BC5BC File Offset: 0x005BA9BC
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node53()
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
			item.skillID = 1011;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060134A0 RID: 79008 RVA: 0x005BC64C File Offset: 0x005BAA4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CED3 RID: 52947
		private List<Input> method_p0;

		// Token: 0x0400CED4 RID: 52948
		private bool method_p1;
	}
}
