using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020024DB RID: 9435
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node23 : Action
	{
		// Token: 0x06013300 RID: 78592 RVA: 0x005B26F0 File Offset: 0x005B0AF0
		public Action_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node23()
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
			item.skillID = 2517;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013301 RID: 78593 RVA: 0x005B2780 File Offset: 0x005B0B80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD1D RID: 52509
		private List<Input> method_p0;

		// Token: 0x0400CD1E RID: 52510
		private bool method_p1;
	}
}
