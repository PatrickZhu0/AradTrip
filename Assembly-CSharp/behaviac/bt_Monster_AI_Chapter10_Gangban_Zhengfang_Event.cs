using System;

namespace behaviac
{
	// Token: 0x0200310E RID: 12558
	public static class bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event
	{
		// Token: 0x06014AC7 RID: 84679 RVA: 0x00639B40 File Offset: 0x00637F40
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Gangban_Zhengfang_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node1 condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node = new Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node1();
			condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node5 condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2 = new Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node5();
			condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3 condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3 = new Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3();
			condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node3.HasEvents());
			Action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2 action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node = new Action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2();
			action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node.HasEvents());
			Action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node4 action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2 = new Action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node4();
			action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
