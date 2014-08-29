print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "########################### Get State ##############################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)


for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.GetState()
	task_list.append(task)
	task.next()

for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking PMaxStateGet for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxStateGet %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			
			if i.GetResult() == 4:
				status = "DISARM"
			if i.GetResult() == 1:
				status = "AWAY"
			if i.GetResult() == 2:
				status = "HOME"
			if i.GetResult() == 7:
				status = "EXIT DELAY to AWAY"
			if i.GetResult() == 8:
				status = "EXIT DELAY to HOME"
			if i.GetResult() == 11:
			   status = "Programming"
			if i.GetResult() == 15:
			   status = "WALK TEST"
			time.sleep (0.5)
			
			SendData ("PMaxStateGet %s SUCCEEDED (%s)." % (i.PanelID(), status))
			time.sleep (0.5)
			
		time.sleep (0.5)