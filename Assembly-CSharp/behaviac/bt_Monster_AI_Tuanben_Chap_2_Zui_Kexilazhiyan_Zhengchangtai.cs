using System;

namespace behaviac
{
	// Token: 0x020037E3 RID: 14307
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai
	{
		// Token: 0x060157BF RID: 87999 RVA: 0x0067C0C0 File Offset: 0x0067A4C0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_Kexilazhiyan_Zhengchangtai");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node0 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node0();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Kexilazhiyan_Zhengchangtai_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
