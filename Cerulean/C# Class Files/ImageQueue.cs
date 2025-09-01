using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public static class ImageFetcher
    {
        private struct ImageJob
        {
            public string Url;
            public PictureBox Target;
            public ImageJob(string url, PictureBox target)
            {
                Url = url;
                Target = target;
            }
        }

        private static Queue<ImageJob> _queue = new Queue<ImageJob>();
        private static bool _isRunning = false;
        //private static Image img;

        public static void QueueImage(string url, PictureBox pb)
        {
            _queue.Enqueue(new ImageJob(url, pb));

            // Start processing if idle
            if (!_isRunning)
            {
                _isRunning = true;
                ProcessNextImage();
            }
        }

        private static void ProcessNextImage()
        {
            if (_queue.Count == 0)
            {
                _isRunning = false;
                return;
            }

            var job = _queue.Dequeue();

            Async.SkyWorker(
                // DoWork
                (s, evt) =>
                {
                    evt.Result = Media.Image.Load(job.Url);
                },
                // Completed
                (s, evt) =>
                {
                    if (evt.Result is Image)
                    {
                        job.Target.Image = (Image)evt.Result;
                    }
                    else
                    {
                        CeruleanBox.Display("Error. URL: " + job.Url + "\n\n");
                        Clipboard.SetText(job.Url);
                        try
                        {
                            CeruleanBox.Display(evt.Result.GetType().ToString());
                        }
                        catch (Exception ex) { CeruleanBox.Display(ex.Message); }
                    }

                    // Move to next image in queue
                    ProcessNextImage();
                }
            );
        }
    }
}