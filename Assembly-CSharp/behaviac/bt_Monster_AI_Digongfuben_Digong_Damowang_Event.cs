using System;

namespace behaviac
{
	// Token: 0x0200324B RID: 12875
	public static class bt_Monster_AI_Digongfuben_Digong_Damowang_Event
	{
		// Token: 0x06014D17 RID: 85271 RVA: 0x0064594C File Offset: 0x00643D4C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Digongfuben/Digong_Damowang_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node4 condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node = new Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node4();
			condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node6 condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2 = new Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node6();
			condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node1 condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3 = new Condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node1();
			condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2 action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node = new Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2();
			action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node7 action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2 = new Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node7();
			action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node2.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3 action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3 = new Action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3();
			action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node3.HasEvents());
			Assignment_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node5 assignment_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node = new Assignment_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node5();
			assignment_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.SetId(5);
			sequence.AddChild(assignment_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Digongfuben_Digong_Damowang_Event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
