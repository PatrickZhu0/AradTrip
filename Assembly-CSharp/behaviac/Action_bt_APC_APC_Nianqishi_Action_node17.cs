using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001DD9 RID: 7641
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Nianqishi_Action_node17 : Action
	{
		// Token: 0x06012568 RID: 75112 RVA: 0x0055AEFC File Offset: 0x005592FC
		public Action_bt_APC_APC_Nianqishi_Action_node17()
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
			item.skillID = 9705;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012569 RID: 75113 RVA: 0x0055AF8C File Offset: 0x0055938C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF57 RID: 48983
		private List<Input> method_p0;

		// Token: 0x0400BF58 RID: 48984
		private bool method_p1;
	}
}
