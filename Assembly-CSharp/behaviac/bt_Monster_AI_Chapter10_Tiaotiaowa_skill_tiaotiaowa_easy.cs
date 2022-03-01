using System;

namespace behaviac
{
	// Token: 0x020030CD RID: 12493
	public static class bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy
	{
		// Token: 0x06014A54 RID: 84564 RVA: 0x00637874 File Offset: 0x00635C74
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Tiaotiaowa/skill_tiaotiaowa_easy");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2 condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node = new Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2();
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node1 condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2 = new Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node1();
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node2.HasEvents());
			Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node3 action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node = new Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node3();
			action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
