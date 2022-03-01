using System;

namespace behaviac
{
	// Token: 0x02003474 RID: 13428
	public static class bt_Monster_AI_Heisedadi_Juewang_Action
	{
		// Token: 0x06015133 RID: 86323 RVA: 0x00659A40 File Offset: 0x00657E40
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Juewang_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(7);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(44);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node45 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node45();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node.SetId(45);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node46 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node2 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node46();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node2.SetId(46);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node2.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node0 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node0();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node3();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Juewang_Action_node48 action_bt_Monster_AI_Heisedadi_Juewang_Action_node = new Action_bt_Monster_AI_Heisedadi_Juewang_Action_node48();
			action_bt_Monster_AI_Heisedadi_Juewang_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Juewang_Action_node.SetId(48);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Juewang_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Juewang_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(39);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node40 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node40();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5.SetId(40);
			sequence2.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node41 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node6 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node41();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node6.SetId(41);
			sequence2.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node6.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node1 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node7 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node1();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node7.SetId(1);
			sequence2.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node7);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node7.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Juewang_Action_node43 action_bt_Monster_AI_Heisedadi_Juewang_Action_node2 = new Action_bt_Monster_AI_Heisedadi_Juewang_Action_node43();
			action_bt_Monster_AI_Heisedadi_Juewang_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Juewang_Action_node2.SetId(43);
			sequence2.AddChild(action_bt_Monster_AI_Heisedadi_Juewang_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Heisedadi_Juewang_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(8);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node8 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node5();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node8.SetId(5);
			sequence3.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node8.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node31 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node9 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node31();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node9.SetId(31);
			sequence3.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node9.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node2 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node10 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node2();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node10.SetId(2);
			sequence3.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node10);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node10.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4 condition_bt_Monster_AI_Heisedadi_Juewang_Action_node11 = new Condition_bt_Monster_AI_Heisedadi_Juewang_Action_node4();
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node11.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Juewang_Action_node11.SetId(4);
			sequence3.AddChild(condition_bt_Monster_AI_Heisedadi_Juewang_Action_node11);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Heisedadi_Juewang_Action_node11.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Juewang_Action_node33 action_bt_Monster_AI_Heisedadi_Juewang_Action_node3 = new Action_bt_Monster_AI_Heisedadi_Juewang_Action_node33();
			action_bt_Monster_AI_Heisedadi_Juewang_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Juewang_Action_node3.SetId(33);
			sequence3.AddChild(action_bt_Monster_AI_Heisedadi_Juewang_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Heisedadi_Juewang_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
