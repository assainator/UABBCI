﻿using System;

namespace UAV.Controllers
{
	public class PasstroughController : AbstractController
	{
		public ICommandProvider CommandProvider { get; set; }

		public PasstroughController (ICommandProvider commandProvider)
		{
			CommandProvider = commandProvider;
			CommandProvider.CommandReceived += HandleCommandReceived;
		}

        public override void StartController()
        {
            CommandProvider.Initialize();

            base.StartController();
        }

        void HandleCommandReceived (object sender, CommandEventArgs e)
		{
			SendFlightCommand (
				roll: 0.0f,
				gaz: 0.0f
			);
		}
	}
}

