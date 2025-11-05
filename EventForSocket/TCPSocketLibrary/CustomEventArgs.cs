using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocket
{
    // <summary>
    // [이벤트 전달용 데이터 클래스]
    // 이벤트 발생 시, 추가 정보를 함께 전달하기 위해 사용하는 클래스입니다.
    // 
    // C#의 모든 이벤트 인자 클래스는 EventArgs를 상속하는 것이 규칙입니다.
    // (ex. MouseEventArgs, KeyEventArgs 등)
    // </summary>
    public class CustomEventArgs : EventArgs
    {
        // <summary>
        // [이벤트 관련 정보]
        // 새로 연결된 클라이언트의 IP 또는 식별 정보를 저장합니다.
        // </summary>
        public string NewClientInfo { get; set; }

        // <summary>
        // [생성자(Constructor)]
        // 이벤트 발생 시 전달할 데이터를 초기화합니다.
        // </summary>
        // <param name="_NewClientInfo">새로 연결된 클라이언트의 정보(IP/Port 등)</param>
        public CustomEventArgs(string _NewClientInfo)
        {
            NewClientInfo = _NewClientInfo;
        }

    }

    // 이벤트 전달용 데이터 클래스
    public class TextReceivedEventArgs : EventArgs
    {
        public string ClientInfo { get; set; }
        public string TextReceived { get; set; }

        public TextReceivedEventArgs(string _clientInfo, string _textReceived)
        {
            ClientInfo = _clientInfo;   
            TextReceived = _textReceived;   
        }
    }






}