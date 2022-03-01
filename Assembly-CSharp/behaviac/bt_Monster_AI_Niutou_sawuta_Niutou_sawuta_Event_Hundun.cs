using System;

namespace behaviac
{
	// Token: 0x02003722 RID: 14114
	public static class bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun
	{
		// Token: 0x06015651 RID: 87633 RVA: 0x0067458C File Offset: 0x0067298C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Niutou_sawuta/Niutou_sawuta_Event_Hundun");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(10);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node11 action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node = new Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node11();
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node.SetId(11);
			sequence.AddChild(action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node.HasEvents());
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(1);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2 condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node = new Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2();
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node.HasEvents());
			Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3 condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2 = new Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3();
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2.HasEvents());
			Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4 condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3 = new Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4();
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3.HasEvents());
			Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5 condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4 = new Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5();
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4.HasEvents());
			Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6 action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2 = new Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6();
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(7);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node8 condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5 = new Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node8();
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5.SetId(8);
			sequence3.AddChild(condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5.HasEvents());
			Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node9 action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3 = new Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node9();
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3.SetId(9);
			sequence3.AddChild(action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(12);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node13 condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6 = new Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node13();
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6.SetId(13);
			sequence4.AddChild(condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node6.HasEvents());
			Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node16 condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node7 = new Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node16();
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node7.SetId(16);
			sequence4.AddChild(condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node7);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node7.HasEvents());
			Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node14 action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4 = new Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node14();
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4.SetId(14);
			sequence4.AddChild(action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4.HasEvents());
			Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node15 action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5 = new Action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node15();
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5.SetId(15);
			sequence4.AddChild(action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
