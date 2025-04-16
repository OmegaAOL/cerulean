using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WebSocket4Net;

namespace Cerulean
{
    class WebsocketTest
    {
        static WebSocket ws;

        public static void socket1()
        {
            ws = new WebSocket("wss://echo.websocket.events");

            ws.Opened += new EventHandler(ws_Opened);
            ws.MessageReceived += new EventHandler<MessageReceivedEventArgs>(ws_MessageReceived);
            ws.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(ws_Error);
            ws.Closed += new EventHandler(ws_Closed);

            ws.Open();
        }

        static void ws_Opened(object sender, EventArgs e)
        {
            MessageBox.Show("Connection opened!");
            ws.Send("Hello! My message."); // Send only *after* connected
        }

        static void ws_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageBox.Show("Received: " + e.Message);
        }

        static void ws_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            MessageBox.Show("Error: " + e.Exception.Message);
        }

        static void ws_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Connection closed.");
        }
    }
}
