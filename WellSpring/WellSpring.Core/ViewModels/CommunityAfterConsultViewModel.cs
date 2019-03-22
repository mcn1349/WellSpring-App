﻿using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class CommunityAfterConsultViewModel
        : MvxViewModel
    {
        private IConsultTableDatabase Iconsult;

        public ConsultTableAutoCompleteResult consultInfo = new ConsultTableAutoCompleteResult();
        
        public ICommand ConcernCommand { get; set; }
        private string receive;

        public void Init(string parameter)
        {
            receive = parameter;
        }

        public CommunityAfterConsultViewModel()
        {
            ConcernCommand = new MvxCommand(() =>
            {
                ShowViewModel<CommunityConcernViewModel>();
            });
        }

        private string _question;
        private int count = 0;
        public override void Start()
        {
            base.Start();
            Question = receive;
        }


        public string Question
        {
            get { return _question; }
            set
            {
                count += 1;
                if (value != null || value == "")
                {
                    SetProperty(ref _question, value);
                }
            }
        }

        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { SetProperty(ref _detail, value); }
        }


        
        private MvxCommand _sendCommand;

        public ICommand SendCommand 
        {
            get
            {
                _sendCommand = _sendCommand ?? new MvxCommand(DoSendInfo);
                return _sendCommand;
            }
        }

        public void DoSendInfo()
        {
            consultInfo.Question = Question;
            consultInfo.Detail = Detail;
            SentToDatabase();
        }


        public async void SentToDatabase()
        {
            Iconsult = new ConsultTableDatabaseAzure();
            if (!await Iconsult.CheckIfExists(consultInfo))
            {
                await Iconsult.InsertConsult(consultInfo);
                Close(this);
                ShowViewModel<HomeViewModel>();
            }
        }



    }
}
