using System;

namespace behaviac
{
	// Token: 0x02003194 RID: 12692
	public static class bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai
	{
		// Token: 0x06014BBE RID: 84926 RVA: 0x0063EA20 File Offset: 0x0063CE20
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter9/9-5_2_Zui_Kexilazhiyan_Shihuatai");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node0 condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node = new Condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node0();
			condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2 action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node = new Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2();
			action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node.HasEvents());
			Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node3 action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2 = new Action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node3();
			action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter9_9_5_2_Zui_Kexilazhiyan_Shihuatai_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
